using System;

namespace BlockBuster.Datos.Entidades
{
    /// <summary>
    /// Información específica de una renta de artículos (fechas, días y estado).
    /// </summary>
    public class Renta
    {
        public int IdRenta { get; set; }
        public int IdTransaccion { get; set; }
        public virtual Transaccion Transaccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaDevolucionPrevista { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }
        public int DiasRenta { get; set; }
        public string Estado { get; set; } // "Activa", "Devuelta", "Vencida"
        public decimal Recargo { get; set; }

        public Renta()
        {
            FechaInicio = DateTime.Now;
            Estado = "Activa";
            Recargo = 0m;
        }
    }
}

