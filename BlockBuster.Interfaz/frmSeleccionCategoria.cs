using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmSeleccionCategoria : Form
    {
        private static frmSeleccionCategoria _instancia;

        /// <summary>
        /// Obtiene la instancia única (Singleton) de la ventana de selección de categorías.
        /// Evita abrir múltiples selectores o ventanas a la vez.
        /// </summary>
        public static frmSeleccionCategoria ObtenerInstancia(string operacion = "Renta")
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new frmSeleccionCategoria(operacion);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(operacion))
                {
                    _instancia.Operacion = operacion;
                }
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

        public static frmSeleccionCategoria Instancia => _instancia;

        /// <summary>
        /// Operación seleccionada previamente ("Renta", "Venta" o "Compra").
        /// </summary>
        public string Operacion { get; set; }

        public frmSeleccionCategoria()
        {
            InitializeComponent();
            Operacion = "Renta";
        }

        public frmSeleccionCategoria(string operacion) : this()
        {
            if (!string.IsNullOrWhiteSpace(operacion))
            {
                Operacion = operacion;
            }
        }

        private void frmSeleccionCategoria_Load(object sender, EventArgs e)
        {
            ActualizarVista();
        }

        public void ActualizarVista()
        {
            lblOperacion.Text = $"Operación: {Operacion?.ToUpper()}";
            this.Text = $"BlockBuster - Selección de Categoría para {Operacion}";

            if (SesionActual.EstaAutenticado)
            {
                lblInfoUsuario.Text = $"Sesión activa: {SesionActual.NombreCompleto} | Rol: {SesionActual.Rol}";
            }
        }

        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            AbrirSiguienteVentana("Películas");
        }

        private void btnVideojuegos_Click(object sender, EventArgs e)
        {
            AbrirSiguienteVentana("Videojuegos");
        }

        private void btnConsolas_Click(object sender, EventArgs e)
        {
            AbrirSiguienteVentana("Consolas");
        }

        /// <summary>
        /// Abre el catálogo con tarjetas para la operación correspondiente (Rentas, Ventas o Compras),
        /// con la categoría ya filtrada y utilizando el patrón Singleton.
        /// </summary>
        private void AbrirSiguienteVentana(string categoria)
        {
            Form parentMdi = this.MdiParent;

            // Abre el catálogo con la operación y la categoría pre-filtrada
            frmCatalogo catalogo = frmCatalogo.ObtenerInstancia(Operacion, categoria);

            if (parentMdi != null)
            {
                // Cerramos cualquier otra ventana hija para que solo haya una opción abierta
                foreach (Form hijo in parentMdi.MdiChildren)
                {
                    if (hijo != catalogo && hijo != this)
                    {
                        hijo.Close();
                    }
                }

                catalogo.MdiParent = parentMdi;
            }

            // Cerramos el selector y mostramos el catálogo Singleton
            this.Close();
            catalogo.Show();
            catalogo.BringToFront();
            catalogo.Activate();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _instancia = null;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

