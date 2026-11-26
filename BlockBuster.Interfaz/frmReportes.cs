using System;
using System.Drawing;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmReportes : Form
    {
        private static frmReportes _instancia;
        private readonly ReporteService _reporteService;

        public static frmReportes ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmReportes();
            }
            else
            {
                _instancia.GenerarReporteActual();

                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;

                _instancia.BringToFront();
                _instancia.Activate();
            }

            return _instancia;
        }

        public frmReportes()
        {
            InitializeComponent();
            _reporteService = new ReporteService();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            if (!PermisosService.PuedeVerReportes())
            {
                MessageBox.Show(
                    $"Acceso denegado: el rol '{SesionActual.Rol}' no tiene permisos para visualizar reportes administrativos.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            dtpInicio.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today;
            GenerarReporteActual();
        }

        public void GenerarReporteActual()
        {
            if (!PermisosService.PuedeVerReportes()) return;

            if (dtpInicio.Value.Date > dtpFin.Value.Date)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resumen = _reporteService.GenerarReporte(
                dtpInicio.Value.Date,
                dtpFin.Value.Date,
                (int)numUmbralStock.Value,
                out string error);

            if (resumen == null)
            {
                MessageBox.Show(error, "Error en Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tarjetas resumen
            lblVentasValor.Text = resumen.TotalVentas.ToString("C2");
            lblVentasDetalle.Text = $"{resumen.CantidadVentas} venta(s) registrada(s)";

            decimal totalRentasConRecargos = resumen.TotalRentas + resumen.TotalRecargos;
            lblRentasValor.Text = totalRentasConRecargos.ToString("C2");
            lblRentasDetalle.Text = $"{resumen.CantidadRentas} renta(s) | Recargos: {resumen.TotalRecargos:C2}";

            lblComprasValor.Text = resumen.TotalCompras.ToString("C2");
            lblComprasDetalle.Text = $"{resumen.CantidadCompras} compra(s) aprobada(s)";

            lblBalanceValor.Text = resumen.BalanceNeto.ToString("C2");
            lblBalanceValor.ForeColor = resumen.BalanceNeto >= 0 ? Color.Gold : Color.Salmon;

            // Grid artículos con menos existencias
            dgvBajoStock.Rows.Clear();
            foreach (var art in resumen.ArticulosBajoStock)
            {
                int idx = dgvBajoStock.Rows.Add(
                    art.Codigo,
                    art.Titulo,
                    art.Tipo,
                    art.Stock,
                    art.PrecioVenta.ToString("C2"),
                    art.PrecioRenta.ToString("C2")
                );

                DataGridViewRow row = dgvBajoStock.Rows[idx];
                if (art.Stock == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(145, 25, 25);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (art.Stock <= 3)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(130, 80, 15);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }

            // Grid detalle de transacciones
            dgvTransacciones.Rows.Clear();
            foreach (var trx in resumen.TransaccionesPeriodo)
            {
                string cliente = trx.Cliente != null
                    ? $"{trx.Cliente.Nombre} {trx.Cliente.Apellido}".Trim()
                    : "N/A";

                dgvTransacciones.Rows.Add(
                    trx.Folio,
                    trx.Fecha.ToString("dd/MM/yyyy HH:mm"),
                    trx.Tipo,
                    cliente,
                    trx.MetodoPago,
                    trx.Total.ToString("C2"),
                    trx.Estado
                );
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            dtpInicio.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today;
            GenerarReporteActual();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            GenerarReporteActual();
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
