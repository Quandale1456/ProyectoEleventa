using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoEleventa.Data
{
    /// <summary>
    /// Data Access Layer para las tablas ventas, detalle_ventas y movimientos_inventario.
    /// Maneja la lógica completa de registro de ventas.
    /// </summary>
    public class VentaDAL
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> _columnsCache =
            new ConcurrentDictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        private static HashSet<string> ObtenerColumnasTabla(string tabla)
        {
            if (string.IsNullOrWhiteSpace(tabla))
                return new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            return _columnsCache.GetOrAdd(tabla, _ =>
            {
                const string q = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @t";
                var dt = DBConnection.ExecuteQuery(q, new SqlParameter("@t", tabla));
                var cols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cols.Add(row["COLUMN_NAME"]?.ToString() ?? string.Empty);
                    }
                }
                return cols;
            });
        }

        private static string ColUsuario(HashSet<string> cols)
        {
            if (cols == null) return null;
            if (cols.Contains("nombre_completo")) return "nombre_completo";
            if (cols.Contains("usuario")) return "usuario";
            if (cols.Contains("nombre_usuario")) return "nombre_usuario";
            if (cols.Contains("username")) return "username";
            if (cols.Contains("nombre")) return "nombre";
            return null;
        }

        /// <summary>
        /// Registra una venta completa dentro de una transacción.
        /// Inserta en ventas, detalle_ventas, actualiza productos y movimientos_inventario.
        /// </summary>
        public static int RegistrarVenta(
            int idCliente,
            decimal subtotal,
            decimal impuesto,
            decimal descuento,
            decimal total,
            string metodoPago,
            int idUsuario,
            DataGridView dgvTicket,
            SqlConnection conn,
            SqlTransaction trans)
        {
            try
            {
                // 1. INSERTAR EN TABLA VENTAS
                string queryVenta = @"
                    INSERT INTO ventas (id_cliente, fecha_venta, subtotal, impuesto, descuento, total, metodo_pago, id_usuario, estado)
                    VALUES (@idCliente, GETDATE(), @subtotal, @impuesto, @descuento, @total, @metodoPago, @idUsuario, 'Completada');
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmdVenta = new SqlCommand(queryVenta, conn, trans);
                cmdVenta.Parameters.AddWithValue("@idCliente", idCliente);
                cmdVenta.Parameters.AddWithValue("@subtotal", subtotal);
                cmdVenta.Parameters.AddWithValue("@impuesto", impuesto);
                cmdVenta.Parameters.AddWithValue("@descuento", descuento);
                cmdVenta.Parameters.AddWithValue("@total", total);
                cmdVenta.Parameters.AddWithValue("@metodoPago", metodoPago);
                cmdVenta.Parameters.AddWithValue("@idUsuario", idUsuario);

                object resultVenta = cmdVenta.ExecuteScalar();
                int idVenta = Convert.ToInt32(resultVenta);

                // 2. INSERTAR DETALLES DE VENTA E ACTUALIZAR INVENTARIO
                foreach (DataGridViewRow row in dgvTicket.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        // Estructura de columnas: 0=código, 1=nombre, 2=precio, 3=cantidad, 4=importe, 5=existencia
                        string codigo = row.Cells[0].Value.ToString();
                        string nombre = row.Cells[1].Value?.ToString() ?? "";
                        decimal cantidad = Convert.ToDecimal(row.Cells[3].Value);
                        decimal precioUnitario = Convert.ToDecimal(row.Cells[2].Value);
                        decimal importeLinea = Convert.ToDecimal(row.Cells[4].Value);
                        decimal descuentoLinea = 0;

                        // Verificar si es un producto común (código "PC")
                        if (codigo.Equals("PC", StringComparison.OrdinalIgnoreCase))
                        {
                            // PRODUCTO COMÚN - Obtener el ID del producto especial "PRODUCTO COMÚN"
                            DataRow productoComun = ProductoDAL.BuscarPorCodigo("PC");
                            int idProductoComun = productoComun != null ? 
                                Convert.ToInt32(productoComun["id_producto"]) : 1;

                            // INSERTAR EN DETALLE_VENTAS para producto común
                            string queryDetalleComun = @"
                                INSERT INTO detalle_ventas (id_venta, id_producto, cantidad, precio_unitario, descuento, subtotal)
                                VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario, @descuentoLinea, @subtotalLinea)";

                            SqlCommand cmdDetalleComun = new SqlCommand(queryDetalleComun, conn, trans);
                            cmdDetalleComun.Parameters.AddWithValue("@idVenta", idVenta);
                            cmdDetalleComun.Parameters.AddWithValue("@idProducto", idProductoComun);
                            cmdDetalleComun.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdDetalleComun.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                            cmdDetalleComun.Parameters.AddWithValue("@descuentoLinea", descuentoLinea);
                            cmdDetalleComun.Parameters.AddWithValue("@subtotalLinea", importeLinea);
                            cmdDetalleComun.ExecuteNonQuery();

                            // No actualizar existencia para productos comunes
                        }
                        else
                        {
                            // PRODUCTO REGISTRADO - Proceso normal
                            // Obtener el ID del producto por código
                            DataRow producto = ProductoDAL.BuscarPorCodigo(codigo);

                            if (producto == null)
                            {
                                throw new Exception($"Producto con código '{codigo}' no encontrado");
                            }

                            int idProducto = Convert.ToInt32(producto["id_producto"]);

                            // INSERTAR EN DETALLE_VENTAS
                            string queryDetalle = @"
                                INSERT INTO detalle_ventas (id_venta, id_producto, cantidad, precio_unitario, descuento, subtotal)
                                VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario, @descuentoLinea, @subtotalLinea)";

                            SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conn, trans);
                            cmdDetalle.Parameters.AddWithValue("@idVenta", idVenta);
                            cmdDetalle.Parameters.AddWithValue("@idProducto", idProducto);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdDetalle.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                            cmdDetalle.Parameters.AddWithValue("@descuentoLinea", descuentoLinea);
                            cmdDetalle.Parameters.AddWithValue("@subtotalLinea", importeLinea);
                            cmdDetalle.ExecuteNonQuery();

                            // ACTUALIZAR EXISTENCIA DEL PRODUCTO
                            string queryActualizarExistencia = @"
                                UPDATE productos
                                SET existencia = existencia - @cantidad
                                WHERE id_producto = @idProducto";

                            SqlCommand cmdActualizar = new SqlCommand(queryActualizarExistencia, conn, trans);
                            cmdActualizar.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdActualizar.Parameters.AddWithValue("@idProducto", idProducto);
                            cmdActualizar.ExecuteNonQuery();

                            // REGISTRAR MOVIMIENTO DE INVENTARIO
                            string queryMovimiento = @"
                                INSERT INTO movimientos_inventario (id_producto, tipo_movimiento, cantidad, fecha_movimiento, referencia)
                                VALUES (@idProducto, 'Salida', @cantidad, GETDATE(), 'VENTA_' + CAST(@idVenta AS VARCHAR))";

                            SqlCommand cmdMovimiento = new SqlCommand(queryMovimiento, conn, trans);
                            cmdMovimiento.Parameters.AddWithValue("@idProducto", idProducto);
                            cmdMovimiento.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdMovimiento.Parameters.AddWithValue("@idVenta", idVenta);
                            cmdMovimiento.ExecuteNonQuery();
                        }
                    }
                }

                // 3. SI ES CRÉDITO, ACTUALIZAR CRÉDITO USADO DEL CLIENTE
                if (metodoPago.ToUpper() == "CRÉDITO")
                {
                    ClienteDAL.ActualizarCreditoUsado(idCliente, total, conn, trans);
                }

                return idVenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error registrando venta: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el historial de ventas de un período.
        /// </summary>
        public static DataTable ObtenerVentasPorPeriodo(DateTime desde, DateTime hasta)
        {
            string query = @"
                SELECT id_venta, c.nombre as cliente, fecha_venta, total, metodo_pago, estado
                FROM ventas v
                JOIN clientes c ON v.id_cliente = c.id_cliente
                WHERE fecha_venta BETWEEN @desde AND @hasta
                ORDER BY fecha_venta DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta)
            };

            return DBConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Obtiene el detalle de una venta específica.
        /// </summary>
        public static DataTable ObtenerDetalleVenta(int idVenta)
        {
            string query = @"
                SELECT dv.id_detalle, p.nombre, dv.cantidad, dv.precio_unitario, dv.descuento, dv.subtotal
                FROM detalle_ventas dv
                JOIN productos p ON dv.id_producto = p.id_producto
                WHERE dv.id_venta = @idVenta";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idVenta", idVenta)
            };

            return DBConnection.ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Obtiene el total de ventas por período.
        /// </summary>
        public static decimal ObtenerTotalVentasPorPeriodo(DateTime desde, DateTime hasta)
        {
            string query = @"
                SELECT SUM(total) FROM ventas
                WHERE fecha_venta BETWEEN @desde AND @hasta";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        /// <summary>
        /// Obtiene el detalle de todas las ventas de un período.
        /// </summary>
        public static DataTable ObtenerDetalleVentasPorPeriodo(DateTime desde, DateTime hasta)
        {
            string query = @"
                SELECT p.codigo_barras, p.nombre, dv.cantidad, dv.precio_unitario, d.nombre as departamento
                FROM detalle_ventas dv
                JOIN productos p ON dv.id_producto = p.id_producto
                JOIN departamentos d ON p.departamento = d.id_departamento
                JOIN ventas v ON dv.id_venta = v.id_venta
                WHERE v.fecha_venta BETWEEN @desde AND @hasta
                ORDER BY v.fecha_venta DESC, p.nombre";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta)
            };

            return DBConnection.ExecuteQuery(query, parameters);
        }

        public static DataTable ObtenerMovimientosInventario(DateTime dia, string tipoMovimiento, string criterio, string valor)
        {
            var colsUsuarios = ObtenerColumnasTabla("usuarios");
            var colUsuario = ColUsuario(colsUsuarios);
            string cajeroExpr = string.IsNullOrWhiteSpace(colUsuario) ? "''" : ("u." + colUsuario);

            string whereTipo = "";
            if (!string.IsNullOrWhiteSpace(tipoMovimiento) && !tipoMovimiento.Equals("- Todos -", StringComparison.OrdinalIgnoreCase))
            {
                // En la BD guardamos: Entrada/Salida/Ajuste. En UI tenemos: Entradas/Salidas/Ventas.
                // Ventas se registran como 'Salida' con referencia 'VENTA_x'.
                if (tipoMovimiento.Equals("Entradas", StringComparison.OrdinalIgnoreCase))
                    whereTipo = " AND mi.tipo_movimiento = 'Entrada'";
                else if (tipoMovimiento.Equals("Salidas", StringComparison.OrdinalIgnoreCase))
                    whereTipo = " AND mi.tipo_movimiento = 'Salida' AND (mi.referencia IS NULL OR mi.referencia NOT LIKE 'VENTA_%')";
                else if (tipoMovimiento.Equals("Ventas", StringComparison.OrdinalIgnoreCase))
                    whereTipo = " AND mi.tipo_movimiento = 'Salida' AND mi.referencia LIKE 'VENTA_%'";
                else
                    whereTipo = " AND mi.tipo_movimiento = @tipoMov";
            }

            string whereFiltro = "";
            if (!string.IsNullOrWhiteSpace(valor))
            {
                string c = (criterio ?? "").Trim();
                if (c.Equals("Cajero", StringComparison.OrdinalIgnoreCase))
                    whereFiltro = string.IsNullOrWhiteSpace(colUsuario) ? "" : (" AND " + cajeroExpr + " LIKE @valor");
                else if (c.Equals("Producto", StringComparison.OrdinalIgnoreCase))
                    whereFiltro = " AND p.nombre LIKE @valor";
                else if (c.Equals("Departamento", StringComparison.OrdinalIgnoreCase))
                    whereFiltro = " AND COALESCE(d.nombre, CONVERT(NVARCHAR(100), p.departamento), '') LIKE @valor";
                else
                    whereFiltro = string.IsNullOrWhiteSpace(colUsuario)
                        ? " AND (p.nombre LIKE @valor OR COALESCE(d.nombre, CONVERT(NVARCHAR(100), p.departamento), '') LIKE @valor)"
                        : (" AND (p.nombre LIKE @valor OR COALESCE(d.nombre, CONVERT(NVARCHAR(100), p.departamento), '') LIKE @valor OR " + cajeroExpr + " LIKE @valor)");
            }

            string query = @"
                SELECT
                    mi.fecha_movimiento,
                    p.nombre AS producto,
                    mi.tipo_movimiento,
                    mi.referencia,
                    mi.cantidad,
                    COALESCE(d.nombre, CONVERT(NVARCHAR(100), p.departamento), '') AS departamento,
                    " + cajeroExpr + @" AS cajero
                FROM movimientos_inventario mi
                INNER JOIN productos p ON mi.id_producto = p.id_producto
                LEFT JOIN departamentos d ON TRY_CONVERT(INT, p.departamento) = d.id_departamento
                OUTER APPLY (
                    SELECT
                        CASE
                            WHEN mi.referencia LIKE 'VENTA_%' THEN TRY_CONVERT(INT, SUBSTRING(mi.referencia, 6, 50))
                            ELSE NULL
                        END AS id_venta
                ) ref
                LEFT JOIN ventas v ON ref.id_venta = v.id_venta
                LEFT JOIN usuarios u ON v.id_usuario = u.id_usuario
                WHERE mi.fecha_movimiento >= @desde AND mi.fecha_movimiento < @hasta" + whereTipo + whereFiltro + @"
                ORDER BY mi.fecha_movimiento DESC";

            var desde = dia.Date;
            var hasta = dia.Date.AddDays(1);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@desde", desde),
                new SqlParameter("@hasta", hasta),
                new SqlParameter("@tipoMov", (object)(tipoMovimiento ?? "") ?? DBNull.Value),
                new SqlParameter("@valor", "%" + (valor ?? "") + "%")
            };

            return DBConnection.ExecuteQuery(query, parameters);
        }
    }
}
