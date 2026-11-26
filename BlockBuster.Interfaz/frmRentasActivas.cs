using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmRentasActivas : Form
    {
        private static frmRentasActivas _instancia;
        private readonly DevolucionService _devolucionService;
        private List<RentaActivaDto> _rentasActivas;

        public static frmRentasActivas ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmRentasActivas();
            }
            else
            {
                _instancia.CargarRentas();

                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;

                _instancia.BringToFront();
                _instancia.Activate();
            }

            return _instancia;
        }

        public frmRentasActivas()
        {
            InitializeComponent();
            _devolucionService = new DevolucionService();
        }

        private void frmRentasActivas_Load(object sender, EventArgs e)
        {
            if (!PermisosService.PuedeRegistrarDevolucion())
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no cuenta con permisos para gestionar rentas activas y devoluciones.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            CargarRentas();
        }

        public void CargarRentas()
        {
            try
            {
                _rentasActivas = _devolucionService.ObtenerRentasActivas(out string error);
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvRentasActivas.Rows.Clear();
                int vencidas = 0;

                foreach (var r in _rentasActivas)
                {
                    int rowIdx = dgvRentasActivas.Rows.Add(
                        r.IdRenta,
                        r.FolioTransaccion,
                        r.ClienteNombre,
                        r.ArticulosResumen,
                        r.FechaInicio.ToString("dd/MM/yyyy"),
                        r.FechaDevolucionPrevista.ToString("dd/MM/yyyy"),
                        r.DiasRetraso > 0 ? $"{r.DiasRetraso} día(s)" : "Al día",
                        r.Estado.ToUpperInvariant(),
                        r.RecargoEstimado.ToString("C2"),
                        r.TotalRenta.ToString("C2")
                    );

                    // Resaltar en rojo las rentas vencidas
                    if (r.EstaVencida)
                    {
                        vencidas++;
                        DataGridViewRow row = dgvRentasActivas.Rows[rowIdx];
                        row.DefaultCellStyle.BackColor = Color.FromArgb(145, 25, 25);
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.SelectionBackColor = Color.Firebrick;
                        row.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                    }
                }

                lblContador.Text = $"Rentas activas: {_rentasActivas.Count} | Vencidas: {vencidas}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la lista de rentas activas:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarRentas();
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            if (!PermisosService.PuedeRegistrarDevolucion())
            {
                MessageBox.Show(
                    $"Su rol '{SesionActual.Rol}' no está autorizado para registrar devoluciones.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dgvRentasActivas.CurrentRow == null || dgvRentasActivas.CurrentRow.Index < 0)
            {
                MessageBox.Show("Por favor, seleccione una renta de la tabla para registrar su devolución.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idRenta = Convert.ToInt32(dgvRentasActivas.CurrentRow.Cells["colIdRenta"].Value);
            string folio = dgvRentasActivas.CurrentRow.Cells["colFolio"].Value?.ToString();
            string cliente = dgvRentasActivas.CurrentRow.Cells["colCliente"].Value?.ToString();
            string recargoTxt = dgvRentasActivas.CurrentRow.Cells["colRecargo"].Value?.ToString();
            string estado = dgvRentasActivas.CurrentRow.Cells["colEstado"].Value?.ToString();

            string msg = $"¿Confirmar la devolución de la renta?\n\n" +
                         $"Folio: {folio}\n" +
                         $"Cliente: {cliente}\n" +
                         $"Estado actual: {estado}\n" +
                         $"Recargo aplicable por retraso: {recargoTxt}\n\n" +
                         $"Los artículos serán regresados automáticamente al inventario.";

            if (MessageBox.Show(msg, "Confirmar Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int idUsuario = SesionActual.EstaAutenticado ? SesionActual.IdUsuario : 1;
            bool ok = _devolucionService.RegistrarDevolucion(
                idRenta,
                idUsuario,
                out decimal recargoCalculado,
                out int diasRetraso,
                out string error);

            if (!ok)
            {
                MessageBox.Show("No se pudo registrar la devolución:\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string detalleRecargo = recargoCalculado > 0
                ? $"\n\n⚠️ Se registró un recargo de {recargoCalculado:C2} por {diasRetraso} día(s) de retraso."
                : "\n\n✔ Entrega puntual sin recargos.";

            MessageBox.Show(
                "¡Devolución registrada exitosamente! El inventario ha sido actualizado." + detalleRecargo,
                "Devolución Exitosa",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            CargarRentas();
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
