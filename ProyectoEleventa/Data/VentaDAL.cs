using System;
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
                        int idProducto = Convert.ToInt32(row.Cells[0].Value);
                        decimal cantidad = Convert.ToDecimal(row.Cells[2].Value);
                        decimal precioUnitario = Convert.ToDecimal(row.Cells[3].Value);
                        decimal descuentoLinea = Convert.ToDecimal(row.Cells[5].Value ?? 0);
                        decimal subtotalLinea = Convert.ToDecimal(row.Cells[6].Value);

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
                        cmdDetalle.Parameters.AddWithValue("@subtotalLinea", subtotalLinea);
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
    }
}
