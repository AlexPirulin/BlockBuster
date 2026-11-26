using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmHistorialTickets : Form
    {
        private static frmHistorialTickets _instancia;
        private readonly TicketService _ticketService;
        private List<Ticket> _ticketsActuales;

        public static frmHistorialTickets ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmHistorialTickets();
            }
            else
            {
                _instancia.CargarTickets();

                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;

                _instancia.BringToFront();
                _instancia.Activate();
            }

            return _instancia;
        }

        public frmHistorialTickets()
        {
            InitializeComponent();
            _ticketService = new TicketService();
        }

        private void frmHistorialTickets_Load(object sender, EventArgs e)
        {
            if (!SesionActual.EstaAutenticado)
            {
                MessageBox.Show("Debe iniciar sesión para consultar el historial de tickets.", "Sesión Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            if (PermisosService.PuedeVerHistorialCompletoTickets())
            {
                lblAlcance.Text = $"Modo {SesionActual.Rol}: Visualizando el historial completo de tickets del sistema.";
            }
            else
            {
                lblAlcance.Text = $"Modo Cliente ({SesionActual.NombreCompleto}): Visualizando únicamente sus propios tickets.";
            }

            CargarTickets();
        }

        public void CargarTickets()
        {
            try
            {
                string folio = txtFolio.Text.Trim();
                string cliente = txtCliente.Text.Trim();
                DateTime? fecha = chkUsarFecha.Checked ? dtpFecha.Value.Date : (DateTime?)null;

                _ticketsActuales = _ticketService.Buscar(folio, fecha, cliente);
                dgvTickets.Rows.Clear();

                foreach (var t in _ticketsActuales)
                {
                    string operacion = t.Transaccion?.Tipo ?? "-";
                    string clienteNombre = t.Transaccion?.Cliente != null
                        ? $"{t.Transaccion.Cliente.Nombre} {t.Transaccion.Cliente.Apellido}".Trim()
                        : "N/A";
                    string usuarioNombre = t.Transaccion?.Usuario?.NombreCompleto ?? "Sistema";
                    string total = t.Transaccion != null ? t.Transaccion.Total.ToString("C2") : "$0.00";

                    dgvTickets.Rows.Add(
                        t.IdTicket,
                        t.Folio,
                        operacion,
                        clienteNombre,
                        usuarioNombre,
                        t.FechaEmision.ToString("dd/MM/yyyy HH:mm"),
                        total,
                        t.RutaArchivo
                    );
                }

                lblContador.Text = $"Tickets encontrados: {_ticketsActuales.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de tickets:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkUsarFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = chkUsarFecha.Checked;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarTickets();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFolio.Clear();
            txtCliente.Clear();
            chkUsarFecha.Checked = false;
            CargarTickets();
        }

        private Ticket ObtenerTicketSeleccionado()
        {
            if (dgvTickets.CurrentRow == null || dgvTickets.CurrentRow.Index < 0)
            {
                MessageBox.Show("Por favor, seleccione un ticket de la lista.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            int idTicket = Convert.ToInt32(dgvTickets.CurrentRow.Cells["colIdTicket"].Value);
            Ticket ticket = _ticketService.ObtenerPorId(idTicket, out string error);

            if (ticket == null)
            {
                MessageBox.Show(error, "No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return ticket;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Ticket ticket = ObtenerTicketSeleccionado();
            if (ticket == null) return;

            if (!_ticketService.PrepararArchivoTicket(ticket, out string rutaFisica, out string errorArchivo))
            {
                MessageBox.Show(
                    "Advertencia al verificar el archivo en disco:\n" + errorArchivo + "\n\nSe mostrará la copia respaldada en la base de datos.",
                    "Aviso de Archivo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            frmTicketViewer.MostrarTicketModal(ticket, this);
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            Ticket ticket = ObtenerTicketSeleccionado();
            if (ticket == null) return;

            if (!_ticketService.PrepararArchivoTicket(ticket, out string rutaFisica, out string errorArchivo))
            {
                MessageBox.Show(
                    "No se pudo preparar el archivo para reimpresión:\n" + errorArchivo,
                    "Error de Archivo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (PrintDocument pd = new PrintDocument())
                {
                    pd.DocumentName = $"Ticket_{ticket.Folio}";
                    string textoImprimir = ticket.ContenidoTexto ?? string.Empty;

                    pd.PrintPage += (s, ev) =>
                    {
                        using (Font fuente = new Font("Consolas", 10f))
                        {
                            ev.Graphics.DrawString(textoImprimir, fuente, Brushes.Black, ev.MarginBounds);
                        }
                    };

                    using (PrintDialog dlg = new PrintDialog())
                    {
                        dlg.Document = pd;
                        dlg.UseEXDialog = true;
                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            pd.Print();
                            MessageBox.Show($"El ticket '{ticket.Folio}' se envió a imprimir correctamente.", "Reimpresión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo completar la impresión física ({ex.Message}).\nEl archivo está disponible y actualizado en:\n{rutaFisica}",
                    "Aviso de Impresión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _instancia = null;
        }
    }
}

