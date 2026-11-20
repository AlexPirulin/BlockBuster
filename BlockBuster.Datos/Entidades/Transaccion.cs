using System;
using System.Collections.Generic;

namespace BlockBuster.Datos.Entidades
{
    /// <summary>
    /// Modelo que representa una transacción de negocio (Renta, Venta o Compra).
    /// </summary>
    public class Transaccion
    {
        public int IdTransaccion { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // "Renta", "Venta", "Compra"
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string MetodoPago { get; set; } // "Efectivo", "Tarjeta"
        public decimal Total { get; set; }
        public string Estado { get; set; } // "Completada", "Pendiente", "Aprobada", "Rechazada", "Cancelada"
        public string Observaciones { get; set; }

        public virtual ICollection<DetalleTransaccion> Detalles { get; set; }
        public virtual Renta Renta { get; set; }
        public virtual Ticket Ticket { get; set; }

        public Transaccion()
        {
            Fecha = DateTime.Now;
            Detalles = new List<DetalleTransaccion>();
            Estado = "Completada";
            MetodoPago = "Efectivo";
        }
    }
}

