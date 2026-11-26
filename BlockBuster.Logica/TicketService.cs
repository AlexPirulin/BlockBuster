using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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

            // 1. Obtener consecutivo único basado en el máximo IdTicket existente
            int consecutivo = (db.Tickets.Select(t => (int?)t.IdTicket).Max() ?? 0) + 1;
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

        /// <summary>
        /// Obtiene un ticket por su ID, verificando permisos de acceso en la lógica.
        /// </summary>
        public Ticket ObtenerPorId(int idTicket, out string mensajeError)
        {
            mensajeError = string.Empty;
            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    var ticket = db.Tickets.FirstOrDefault(t => t.IdTicket == idTicket);
                    if (ticket == null)
                    {
                        mensajeError = "El ticket solicitado no existe en la base de datos.";
                        return null;
                    }

                    ticket.Transaccion = db.Transacciones.FirstOrDefault(tr => tr.IdTransaccion == ticket.IdTransaccion);
                    if (ticket.Transaccion != null)
                    {
                        ticket.Transaccion.Cliente = db.Clientes.Find(ticket.Transaccion.IdCliente);
                        ticket.Transaccion.Usuario = db.Usuarios.Find(ticket.Transaccion.IdUsuario);
                    }

                    if (SesionActual.EstaAutenticado && !PermisosService.PuedeVerHistorialCompletoTickets())
                    {
                        if (ticket.Transaccion == null || ticket.Transaccion.IdUsuario != SesionActual.IdUsuario)
                        {
                            mensajeError = "Acceso denegado: como Cliente solo puede consultar sus propios tickets.";
                            return null;
                        }
                    }

                    return ticket;
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Error al consultar el ticket en la base de datos: " + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Método auxiliar que carga únicamente las transacciones, clientes y usuarios referenciados
        /// por la lista de tickets dada (evita cargar tablas completas en memoria).
        /// </summary>
        private void CargarRelacionesTickets(BlockBusterDbContext db, List<Ticket> tickets)
        {
            if (tickets == null || tickets.Count == 0) return;

            var idsTrx = tickets.Select(t => t.IdTransaccion).Distinct().ToList();
            var transacciones = db.Transacciones
                .AsNoTracking()
                .Where(tr => idsTrx.Contains(tr.IdTransaccion))
                .ToDictionary(tr => tr.IdTransaccion);

            var idsClientes = transacciones.Values.Select(tr => tr.IdCliente).Distinct().ToList();
            var idsUsuarios = transacciones.Values.Select(tr => tr.IdUsuario).Distinct().ToList();

            var clientes = db.Clientes.AsNoTracking().Where(c => idsClientes.Contains(c.IdCliente)).ToDictionary(c => c.IdCliente);
            var usuarios = db.Usuarios.AsNoTracking().Where(u => idsUsuarios.Contains(u.IdUsuario)).ToDictionary(u => u.IdUsuario);

            foreach (var t in tickets)
            {
                if (transacciones.TryGetValue(t.IdTransaccion, out var trx))
                {
                    if (clientes.TryGetValue(trx.IdCliente, out var cli)) trx.Cliente = cli;
                    if (usuarios.TryGetValue(trx.IdUsuario, out var usr)) trx.Usuario = usr;
                    t.Transaccion = trx;
                }
            }
        }

        /// <summary>
        /// Busca tickets filtrando por folio, fecha y/o nombre de cliente.
        /// Respeta permisos en la lógica: Admin y Caja ven el historial completo; Cliente solo ve los suyos.
        /// </summary>
        public List<Ticket> Buscar(string folio = null, DateTime? fecha = null, string cliente = null)
        {
            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    IQueryable<Ticket> query = db.Tickets.AsNoTracking();

                    // Validación de permisos en la lógica: Cliente solo ve los propios
                    if (SesionActual.EstaAutenticado && !PermisosService.PuedeVerHistorialCompletoTickets())
                    {
                        int idUsr = SesionActual.IdUsuario;
                        var idsTrxUsuario = db.Transacciones
                            .AsNoTracking()
                            .Where(tr => tr.IdUsuario == idUsr)
                            .Select(tr => tr.IdTransaccion);
                        query = query.Where(t => idsTrxUsuario.Contains(t.IdTransaccion));
                    }

                    if (fecha.HasValue)
                    {
                        DateTime inicioDia = fecha.Value.Date;
                        DateTime finDia = inicioDia.AddDays(1);
                        query = query.Where(t => t.FechaEmision >= inicioDia && t.FechaEmision < finDia);
                    }

                    var tickets = query.OrderByDescending(t => t.FechaEmision).ToList();
                    CargarRelacionesTickets(db, tickets);

                    IEnumerable<Ticket> consulta = tickets;

                    if (!string.IsNullOrWhiteSpace(folio))
                    {
                        string f = folio.Trim().ToLowerInvariant();
                        consulta = consulta.Where(t =>
                            (!string.IsNullOrEmpty(t.Folio) && t.Folio.ToLowerInvariant().Contains(f)) ||
                            (t.Transaccion != null && !string.IsNullOrEmpty(t.Transaccion.Folio) && t.Transaccion.Folio.ToLowerInvariant().Contains(f)));
                    }

                    if (!string.IsNullOrWhiteSpace(cliente))
                    {
                        string c = cliente.Trim().ToLowerInvariant();
                        consulta = consulta.Where(t =>
                            t.Transaccion?.Cliente != null &&
                            ($"{t.Transaccion.Cliente.Nombre} {t.Transaccion.Cliente.Apellido}").ToLowerInvariant().Contains(c));
                    }

                    return consulta.ToList();
                }
            }
            catch
            {
                return new List<Ticket>();
            }
        }

        /// <summary>
        /// Obtiene todos los tickets emitidos para un usuario específico.
        /// </summary>
        public List<Ticket> ObtenerPorUsuario(int idUsuario)
        {
            if (idUsuario <= 0) return new List<Ticket>();

            try
            {
                using (var db = new BlockBusterDbContext())
                {
                    var idsTrx = db.Transacciones
                        .AsNoTracking()
                        .Where(tr => tr.IdUsuario == idUsuario)
                        .Select(tr => tr.IdTransaccion);

                    var tickets = db.Tickets
                        .AsNoTracking()
                        .Where(t => idsTrx.Contains(t.IdTransaccion))
                        .OrderByDescending(t => t.FechaEmision)
                        .ToList();

                    CargarRelacionesTickets(db, tickets);
                    return tickets;
                }
            }
            catch
            {
                return new List<Ticket>();
            }
        }

        /// <summary>
        /// Prepara el archivo físico de un ticket para reabrirlo o reimprimirlo.
        /// Si falta la carpeta 'Tickets' o el archivo en disco, lo reconstruye desde ContenidoTexto en la BD.
        /// Detecta si el archivo está abierto o bloqueado por otro proceso.
        /// </summary>
        public bool PrepararArchivoTicket(Ticket ticket, out string rutaFisica, out string mensajeError)
        {
            rutaFisica = string.Empty;
            mensajeError = string.Empty;

            if (ticket == null)
            {
                mensajeError = "No se proporcionó un ticket válido.";
                return false;
            }

            try
            {
                // Garantizar que la carpeta Tickets exista
                string dirTickets = DirectorioTickets;
                if (!Directory.Exists(dirTickets))
                {
                    Directory.CreateDirectory(dirTickets);
                }

                string rutaGuardada = ticket.RutaArchivo;
                if (string.IsNullOrWhiteSpace(rutaGuardada) || rutaGuardada.StartsWith("Error", StringComparison.OrdinalIgnoreCase))
                {
                    rutaGuardada = Path.Combine(CarpetaTickets, $"Ticket_{ticket.Folio}_{ticket.FechaEmision:yyyyMMdd_HHmmss}.txt");
                }

                rutaFisica = Path.IsPathRooted(rutaGuardada)
                    ? rutaGuardada
                    : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaGuardada);

                string carpetaPadre = Path.GetDirectoryName(rutaFisica);
                if (!string.IsNullOrWhiteSpace(carpetaPadre) && !Directory.Exists(carpetaPadre))
                {
                    Directory.CreateDirectory(carpetaPadre);
                }

                if (!File.Exists(rutaFisica))
                {
                    string contenido = string.IsNullOrWhiteSpace(ticket.ContenidoTexto)
                        ? $"FOLIO: {ticket.Folio}\r\nFECHA: {ticket.FechaEmision:dd/MM/yyyy HH:mm:ss}\r\n"
                        : ticket.ContenidoTexto;

                    File.WriteAllText(rutaFisica, contenido, Encoding.UTF8);
                }
                else
                {
                    // Verificar que el archivo no esté bloqueado / abierto de forma exclusiva
                    using (FileStream fs = File.Open(rutaFisica, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        // Lectura verificada
                    }
                }

                return true;
            }
            catch (IOException ex)
            {
                mensajeError = $"El archivo del ticket '{ticket.Folio}' se encuentra abierto o bloqueado por otro programa.\nDetalle: {ex.Message}";
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                mensajeError = $"No tiene permisos suficientes para acceder o crear el archivo del ticket.\nDetalle: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error inesperado al preparar el ticket: {ex.Message}";
                return false;
            }
        }
    }
}

