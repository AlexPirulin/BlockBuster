using System;

namespace BlockBuster.Datos.Entidades
{
    /// <summary>
    /// Detalle o renglón de una transacción comercial.
    /// </summary>
    public class DetalleTransaccion
    {
        public int IdDetalleTransaccion { get; set; }
        public int IdTransaccion { get; set; }
        public virtual Transaccion Transaccion { get; set; }
        public int? IdArticulo { get; set; }
        public virtual Articulo Articulo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}

