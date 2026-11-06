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
        /// Abre la ventana de la operación correspondiente (Rentas, Ventas o Compras),
        /// utilizando Singleton para que no se puedan abrir todas las opciones a la vez.
        /// </summary>
        private void AbrirSiguienteVentana(string categoria)
        {
            Form frmDestino = null;
            Form parentMdi = this.MdiParent;

            string opNormalizada = Operacion?.Trim().ToLower() ?? "renta";

            switch (opNormalizada)
            {
                case "renta":
                case "rentas":
                    frmDestino = frmRentas.ObtenerInstancia(Operacion, categoria);
                    break;

                case "venta":
                case "ventas":
                    frmDestino = frmVentas.ObtenerInstancia(Operacion, categoria);
                    break;

                case "compra":
                case "compras":
                    frmDestino = frmCompras.ObtenerInstancia(Operacion, categoria);
                    break;

                default:
                    frmDestino = frmRentas.ObtenerInstancia(Operacion, categoria);
                    break;
            }

            if (parentMdi != null)
            {
                // Cerramos cualquier otra ventana hija para que solo haya una opción abierta
                foreach (Form hijo in parentMdi.MdiChildren)
                {
                    if (hijo != frmDestino && hijo != this)
                    {
                        hijo.Close();
                    }
                }

                frmDestino.MdiParent = parentMdi;
            }

            // Cerramos el selector y mostramos la ventana de operación Singleton
            this.Close();
            frmDestino.Show();
            frmDestino.BringToFront();
            frmDestino.Activate();
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

