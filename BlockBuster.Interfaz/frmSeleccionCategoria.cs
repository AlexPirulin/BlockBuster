using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmSeleccionCategoria : Form
    {
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
            // Muestra en pantalla la operación elegida y la información de la sesión actual
            lblOperacion.Text = $"Operación: {Operacion.ToUpper()}";
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
        /// pasando la operación elegida y la categoría seleccionada.
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
                    frmDestino = new frmRentas(Operacion, categoria);
                    break;

                case "venta":
                case "ventas":
                    frmDestino = new frmVentas(Operacion, categoria);
                    break;

                case "compra":
                case "compras":
                    frmDestino = new frmCompras(Operacion, categoria);
                    break;

                default:
                    frmDestino = new frmRentas(Operacion, categoria);
                    break;
            }

            if (parentMdi != null)
            {
                frmDestino.MdiParent = parentMdi;
            }

            this.Close();
            frmDestino.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
