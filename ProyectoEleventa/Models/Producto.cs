using System;

namespace ProyectoEleventa.Models
{
    /// <summary>
    /// Clase modelo que representa un producto del sistema.
    /// Encapsula los datos de un producto con validaciones.
    /// </summary>
    public class Producto
    {
        public int IdProducto { get; set; }
        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Existencia { get; set; }
        public int DepartamentoId { get; set; }
        public bool UsaInventario { get; set; }
        public decimal ExistenciaMinima { get; set; }
        public decimal ExistenciaMaxima { get; set; }

        public Producto()
        {
            IdProducto = 0;
            CodigoBarras = "";
            Nombre = "";
            PrecioCosto = 0;
            PorcentajeGanancia = 0;
            PrecioVenta = 0;
            Existencia = 0;
            DepartamentoId = 0;
            UsaInventario = false;
            ExistenciaMinima = 0;
            ExistenciaMaxima = 0;
        }

        /// <summary>
        /// Calcula el precio de venta basado en costo y porcentaje de ganancia.
        /// Fórmula: PrecioVenta = Costo + (Costo * PorcentajeGanancia / 100)
        /// </summary>
        public decimal CalcularPrecioVenta()
        {
            if (PrecioCosto <= 0)
                return 0;

            return PrecioCosto + (PrecioCosto * PorcentajeGanancia / 100);
        }

        /// <summary>
        /// Valida que los datos del producto sean correctos.
        /// </summary>
        public bool Validar(out string mensajeError)
        {
            mensajeError = "";

            if (string.IsNullOrWhiteSpace(CodigoBarras))
            {
                mensajeError = "El código de barras es requerido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                mensajeError = "El nombre del producto es requerido.";
                return false;
            }

            if (PrecioCosto <= 0)
            {
                mensajeError = "El precio de costo debe ser mayor a 0.";
                return false;
            }

            if (PorcentajeGanancia < 0)
            {
                mensajeError = "El porcentaje de ganancia no puede ser negativo.";
                return false;
            }

            if (PrecioVenta <= 0)
            {
                mensajeError = "El precio de venta debe ser mayor a 0.";
                return false;
            }

            return true;
        }
    }
}
