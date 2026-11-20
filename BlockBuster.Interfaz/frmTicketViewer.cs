using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Interfaz
{
    public partial class frmTicketViewer : Form
    {
        private readonly Ticket _ticket;

        public frmTicketViewer(Ticket ticket)
        {
            InitializeComponent();
            _ticket = ticket;

            if (_ticket != null)
            {
                lblTitulo.Text = $"COMPROBANTE: {_ticket.Folio}";
                rtbTicket.Text = _ticket.ContenidoTexto ?? string.Empty;
                lblSubtitulo.Text = $"Archivo: {_ticket.RutaArchivo}";
            }
        }

        public static void MostrarTicketModal(Ticket ticket, IWin32Window parent = null)
        {
            if (ticket == null) return;

            using (var viewer = new frmTicketViewer(ticket))
            {
                if (parent != null)
                {
                    viewer.ShowDialog(parent);
                }
                else
                {
                    viewer.ShowDialog();
                }
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbTicket.Text))
            {
                Clipboard.SetText(rtbTicket.Text);
                MessageBox.Show("Contenido copiado al portapapeles.", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            if (_ticket == null || string.IsNullOrEmpty(_ticket.RutaArchivo))
            {
                MessageBox.Show("No se encontró la ruta del archivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string rutaFisica = Path.IsPathRooted(_ticket.RutaArchivo)
                    ? _ticket.RutaArchivo
                    : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _ticket.RutaArchivo);

                if (File.Exists(rutaFisica))
                {
                    Process.Start("notepad.exe", rutaFisica);
                }
                else
                {
                    MessageBox.Show($"El archivo físico no fue localizado en:\n{rutaFisica}", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar abrir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

