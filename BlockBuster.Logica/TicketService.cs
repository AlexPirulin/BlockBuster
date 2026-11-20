using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio para la generación, persistencia en disco y registro en base de datos de tickets y recibos.
    /// Crea automáticamente la carpeta 'Tickets' y genera folios consecutivos únicos.
    /// </summary>
    public class TicketService
    {
        private const string CarpetaTickets = "Tickets";

        /// <summary>
        /// Obtiene o crea la ruta física del directorio 'Tickets' en el directorio de ejecución.
        /// </summary>
        public static string DirectorioTickets
        {
            get
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CarpetaTickets);
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        // En caso de permisos, usar ruta alternativa
                    }
                }
                return path;
            }
        }

        /// <summary>
        /// Genera un ticket oficial con folio consecutivo, guarda el archivo de texto en disco
        /// y registra el objeto Ticket en la base de datos dentro del contexto de la transacción.
        /// </summary>
        public Ticket Generar(
            BlockBusterDbContext db,
            Transaccion transaccion,
            Cliente cliente,
            Usuario usuario,
            List<DetalleTransaccion> detalles,
            Renta renta = null)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));
            if (transaccion == null) throw new ArgumentNullException(nameof(transaccion));

            // 1. Obtener consecutivo para el folio único
            int totalTickets = db.Tickets.Count();
            int consecutivo = totalTickets + 1;
            string folio = $"TKT-{consecutivo:D5}";

            // 2. Construir el texto formateado del ticket
            string contenidoTicket = ConstruirTextoTicket(folio, transaccion, cliente, usuario, detalles, renta);

            // 3. Guardar el archivo en la carpeta 'Tickets'
            string nombreArchivo = $"Ticket_{folio}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string rutaCompleta = Path.Combine(DirectorioTickets, nombreArchivo);
            string rutaRelativa = Path.Combine(CarpetaTickets, nombreArchivo);

            try
            {
                File.WriteAllText(rutaCompleta, contenidoTicket, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                // Si falla la escritura en disco, se continúa pero se registra la anomalía
                rutaRelativa = "Error de escritura: " + ex.Message;
            }

            // 4. Crear y registrar entidad Ticket en la base de datos
            Ticket ticket = new Ticket
            {
                Folio = folio,
                IdTransaccion = transaccion.IdTransaccion,
                FechaEmision = DateTime.Now,
                RutaArchivo = rutaRelativa,
                ContenidoTexto = contenidoTicket
            };

            db.Tickets.Add(ticket);
            db.SaveChanges();

            return ticket;
        }

        /// <summary>
        /// Construye el diseño visual de recibo tipo ticket BlockBuster.
        /// </summary>
        public string ConstruirTextoTicket(
            string folio,
            Transaccion transaccion,
            Cliente cliente,
            Usuario usuario,
            List<DetalleTransaccion> detalles,
            Renta renta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==================================================");
            sb.AppendLine("                 BLOCKBUSTER VIDEO                ");
            sb.AppendLine("         La Experiencia del Entretenimiento       ");
            sb.AppendLine("==================================================");
            sb.AppendLine($"FOLIO TICKET : {folio}");
            sb.AppendLine($"FOLIO TRANS. : {transaccion.Folio ?? "N/A"}");
            sb.AppendLine($"FECHA Y HORA : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"OPERACION    : {transaccion.Tipo?.ToUpper()}");
            sb.AppendLine($"ESTADO       : {transaccion.Estado?.ToUpper()}");
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine($"CLIENTE      : {cliente?.Nombre} {cliente?.Apellido}");
            sb.AppendLine($"TELEFONO     : {cliente?.Telefono ?? "Sin registro"}");
            sb.AppendLine($"EMAIL        : {cliente?.Email ?? "Sin registro"}");
            sb.AppendLine($"ATENDIDO POR : {usuario?.NombreCompleto ?? "Sistema"} ({usuario?.Rol ?? "N/A"})");
            sb.AppendLine($"METODO PAGO  : {transaccion.MetodoPago ?? "Efectivo"}");

            if (renta != null)
            {
                sb.AppendLine("--------------------------------------------------");
                sb.AppendLine("PERIODO DE RENTA:");
                sb.AppendLine($"  Días de Renta      : {renta.DiasRenta} días");
                sb.AppendLine($"  Fecha de Renta     : {renta.FechaInicio:dd/MM/yyyy HH:mm}");
                sb.AppendLine($"  Devolución Prevista: {renta.FechaDevolucionPrevista:dd/MM/yyyy}");
                sb.AppendLine($"  Estado de Renta    : {renta.Estado}");
            }

            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("CANT  DESCRIPCION                 P.UNIT     TOTAL");
            sb.AppendLine("--------------------------------------------------");

            if (detalles != null && detalles.Count > 0)
            {
                foreach (var d in detalles)
                {
                    string desc = d.Descripcion ?? "Artículo";
                    if (desc.Length > 24) desc = desc.Substring(0, 24);

                    sb.AppendLine($"{d.Cantidad,4}  {desc,-24}  {d.PrecioUnitario,8:C2}  {d.Subtotal,8:C2}");
                }
            }

            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine($"TOTAL A PAGAR/RECIBIR: {transaccion.Total,24:C2}");
            sb.AppendLine("==================================================");

            if (transaccion.Tipo == "Renta")
            {
                sb.AppendLine(" NOTA IMPORTANTE DE RENTA:                       ");
                sb.AppendLine(" Favor de devolver el material antes de la fecha ");
                sb.AppendLine(" límite. Aplica recargo diario por entrega tardía.");
            }
            else if (transaccion.Tipo == "Compra")
            {
                sb.AppendLine(" NOTA DE COMPRA A CLIENTE:                        ");
                sb.AppendLine(" Artículo valuado y recibido conforme a políticas");
                sb.AppendLine(" de revisión de estado físico y funcionamiento.   ");
            }
            else
            {
                sb.AppendLine(" ¡GRACIAS POR SU COMPRA!                          ");
                sb.AppendLine(" Conserve este comprobante para cualquier garantía.");
            }

            sb.AppendLine("==================================================");
            sb.AppendLine("            www.blockbuster-video.com             ");
            sb.AppendLine("==================================================");

            return sb.ToString();
        }

        /// <summary>
        /// Obtiene un ticket por el ID de la transacción.
        /// </summary>
        public Ticket ObtenerPorTransaccion(int idTransaccion)
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Tickets.FirstOrDefault(t => t.IdTransaccion == idTransaccion);
            }
        }
    }
}

