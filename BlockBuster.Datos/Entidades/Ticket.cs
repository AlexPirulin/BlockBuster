using System;

namespace BlockBuster.Datos.Entidades
{
    /// <summary>
    /// Comprobante o ticket generado para una transacción.
    /// Registra el folio correlativo y la ruta física del archivo generado en la carpeta Tickets.
    /// </summary>
    public class Ticket
    {
        public int IdTicket { get; set; }
        public string Folio { get; set; }
        public int IdTransaccion { get; set; }
        public virtual Transaccion Transaccion { get; set; }
        public DateTime FechaEmision { get; set; }
        public string RutaArchivo { get; set; }
        public string ContenidoTexto { get; set; }

        public Ticket()
        {
            FechaEmision = DateTime.Now;
        }
    }
}

