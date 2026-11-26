using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmConfiguracion : Form
    {
        private static frmConfiguracion _instancia;
        private readonly ConfiguracionService _configService;

        public static frmConfiguracion ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmConfiguracion();
            }
            else
            {
                _instancia.CargarValores();

                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;

                _instancia.BringToFront();
                _instancia.Activate();
            }

            return _instancia;
        }

        public frmConfiguracion()
        {
            InitializeComponent();
            _configService = new ConfiguracionService();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            if (!PermisosService.PuedeConfigurarSistema())
            {
                MessageBox.Show(
                    $"Acceso denegado: el rol '{SesionActual.Rol}' no tiene permisos para modificar la configuración.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            CargarValores();
        }

        public void CargarValores()
        {
            try
            {
                numTarifaRecargo.Value = Math.Max(0, _configService.ObtenerDecimal("TarifaRecargoPorDia", 15.00m));
                numDiasMinimos.Value = Math.Max(1, _configService.ObtenerInt("DiasMinimosRenta", 1));
                numDiasMaximos.Value = Math.Max(1, _configService.ObtenerInt("DiasMaximosRenta", 14));

                numPorcExcelente.Value = Math.Min(100, Math.Max(0, _configService.ObtenerDecimal("PorcentajeValuacionExcelente", 0.70m) * 100m));
                numPorcBueno.Value = Math.Min(100, Math.Max(0, _configService.ObtenerDecimal("PorcentajeValuacionBueno", 0.50m) * 100m));
                numPorcRegular.Value = Math.Min(100, Math.Max(0, _configService.ObtenerDecimal("PorcentajeValuacionRegular", 0.30m) * 100m));
                numPorcMalo.Value = Math.Min(100, Math.Max(0, _configService.ObtenerDecimal("PorcentajeValuacionMalo", 0.15m) * 100m));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la configuración:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!PermisosService.PuedeConfigurarSistema())
            {
                MessageBox.Show("Acceso denegado: solo el Administrador puede guardar cambios de configuración.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numDiasMinimos.Value > numDiasMaximos.Value)
            {
                MessageBox.Show("Los días mínimos de renta no pueden ser mayores a los días máximos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ok = _configService.GuardarConfiguracionGeneral(
                numTarifaRecargo.Value,
                numPorcExcelente.Value / 100m,
                numPorcBueno.Value / 100m,
                numPorcRegular.Value / 100m,
                numPorcMalo.Value / 100m,
                (int)numDiasMinimos.Value,
                (int)numDiasMaximos.Value,
                out string mensajeError);

            if (!ok)
            {
                MessageBox.Show("No se pudo guardar la configuración:\n" + mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(
                "Configuración guardada y aplicada correctamente.",
                "Configuración Actualizada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

