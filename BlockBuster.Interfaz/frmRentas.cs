using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmRentas : Form
    {
        private static frmRentas _instancia;

        /// <summary>
        /// Obtiene la instancia única (Singleton) de la ventana de Rentas.
        /// Evita abrir múltiples instancias de la misma opción a la vez.
        /// </summary>
        public static frmRentas ObtenerInstancia(string operacion = "Renta", string categoria = "Películas")
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmRentas(operacion, categoria);
            }
            else
            {
                _instancia.Operacion = operacion ?? "Renta";
                _instancia.Categoria = categoria ?? "Películas";
                _instancia.ActualizarVista();

                if (_instancia.WindowState == FormWindowState.Minimized)
                {
                    _instancia.WindowState = FormWindowState.Normal;
                }
                _instancia.BringToFront();
                _instancia.Activate();
            }

            return _instancia;
        }

        public static frmRentas Instancia => _instancia;

        public string Operacion { get; set; } = "Renta";
        public string Categoria { get; set; } = "Películas";

        public frmRentas()
        {
            InitializeComponent();
        }

        public frmRentas(string operacion, string categoria) : this()
        {
            Operacion = operacion ?? "Renta";
            Categoria = categoria ?? "Películas";
        }

        private void frmRentas_Load(object sender, EventArgs e)
        {
            ActualizarVista();
        }

        public void ActualizarVista()
        {
            lblOperacionCategoria.Text = $"MÓDULO DE {Operacion.ToUpper()}: {Categoria.ToUpper()}";
            this.Text = $"BlockBuster - {Operacion} de {Categoria}";
            lblMensajeContenido.Text = $"Catálogo de {Categoria} disponible para la operación de {Operacion}.";

            if (SesionActual.EstaAutenticado)
            {
                lblUsuarioSesion.Text = $"Usuario: {SesionActual.NombreCompleto} ({SesionActual.NombreUsuario}) | Rol: {SesionActual.Rol}";
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _instancia = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
