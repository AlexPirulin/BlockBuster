using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarInformacionUsuario();
            AplicarPermisos();
        }

        /// <summary>
        /// Muestra en la ventana principal el nombre completo y el rol guardados en SesionActual.
        /// </summary>
        public void ActualizarInformacionUsuario()
        {
            if (SesionActual.EstaAutenticado)
            {
                string infoUsuario = $"{SesionActual.NombreCompleto} ({SesionActual.NombreUsuario})";
                string infoRol = SesionActual.Rol;

                // 1. Título de la ventana
                this.Text = $"BlockBuster - Sistema Principal | Usuario: {infoUsuario} | Rol: {infoRol}";

                // 2. Etiquetas visuales en el panel superior
                lblUsuarioActual.Text = $"Usuario: {infoUsuario}";
                lblRolActual.Text = $"Rol: {infoRol}";

                // 3. Barra de estado inferior
                lblStatusUsuario.Text = $"Usuario: {infoUsuario}";
                lblStatusRol.Text = $"Rol: {infoRol}";
            }
            else
            {
                this.Text = "BlockBuster - Sistema Principal | Sesión no iniciada";
                lblUsuarioActual.Text = "Usuario: No autenticado";
                lblRolActual.Text = "Rol: -";
                lblStatusUsuario.Text = "Usuario: -";
                lblStatusRol.Text = "Rol: -";
            }
        }

        /// <summary>
        /// Aplica la autorización y permisos según el rol del usuario utilizando PermisosService.
        /// </summary>
        public void AplicarPermisos()
        {
            bool puedeRentar = PermisosService.PuedeRealizarRentas();
            bool puedeVender = PermisosService.PuedeRealizarVentas();
            bool puedeComprar = PermisosService.PuedeRealizarCompras();

            // Botones de la barra principal
            btnRenta.Enabled = puedeRentar;
            btnVenta.Enabled = puedeVender;
            btnCompra.Enabled = puedeComprar;

            // Opciones del menú superior
            rentaToolStripMenuItem.Enabled = puedeRentar;
            ventaToolStripMenuItem.Enabled = puedeVender;
            compraToolStripMenuItem.Enabled = puedeComprar;
        }

        #region Eventos de Botones Principales

        private void btnRenta_Click(object sender, EventArgs e)
        {
            EjecutarOperacion("Renta");
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            EjecutarOperacion("Venta");
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            EjecutarOperacion("Compra");
        }

        #endregion

        #region Eventos del Menú Superior

        private void rentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarOperacion("Renta");
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarOperacion("Venta");
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarOperacion("Compra");
        }

        #endregion

        /// <summary>
        /// Abre la ventana de selección de categoría pasando qué operación se eligió (Renta, Venta o Compra).
        /// </summary>
        private void EjecutarOperacion(string operacion)
        {
            // Verificación previa de permisos con PermisosService
            string opLower = operacion?.ToLower() ?? "";
            bool autorizado = true;

            if (opLower.Contains("compra") && !PermisosService.PuedeRealizarCompras())
            {
                autorizado = false;
            }
            else if (opLower.Contains("venta") && !PermisosService.PuedeRealizarVentas())
            {
                autorizado = false;
            }
            else if (opLower.Contains("renta") && !PermisosService.PuedeRealizarRentas())
            {
                autorizado = false;
            }

            if (!autorizado)
            {
                MessageBox.Show(
                    $"Su rol actual ({SesionActual.Rol}) no cuenta con permisos para realizar operaciones de {operacion}.",
                    "Acceso Restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Abre la ventana de selección de categorías dentro del contenedor MDI
            frmSeleccionCategoria selector = new frmSeleccionCategoria(operacion);
            selector.MdiParent = this;
            selector.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea cerrar la sesión actual?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // Limpia la sesión actual
                SesionActual.CerrarSesion();

                // Cierra la ventana principal; Program.cs vuelve a mostrar el login
                this.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}