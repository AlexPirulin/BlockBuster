using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmCompras : Form
    {
        private static frmCompras _instancia;

        /// <summary>
        /// Obtiene la instancia única (Singleton) de la ventana de Compras.
        /// Evita abrir múltiples instancias de la misma opción a la vez.
        /// </summary>
        public static frmCompras ObtenerInstancia(string operacion = "Compra", string categoria = "Películas")
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmCompras(operacion, categoria);
            }
            else
            {
                _instancia.Operacion = operacion ?? "Compra";
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

        public static frmCompras Instancia => _instancia;

        public string Operacion { get; set; } = "Compra";
        public string Categoria { get; set; } = "Películas";

        public frmCompras()
        {
            InitializeComponent();
        }

        public frmCompras(string operacion, string categoria) : this()
        {
            Operacion = operacion ?? "Compra";
            Categoria = categoria ?? "Películas";
        }

        private void frmCompras_Load(object sender, EventArgs e)
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
