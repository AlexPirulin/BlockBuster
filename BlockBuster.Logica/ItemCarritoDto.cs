using System;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Estructura de transferencia de datos para artículos en carritos de venta y renta.
    /// </summary>
    public class ItemCarritoDto
    {
        public int IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}

