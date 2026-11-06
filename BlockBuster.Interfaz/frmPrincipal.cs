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
            ActualizarInformacionUsuario();
            AplicarPermisos();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarInformacionUsuario();
            AplicarPermisos();
        }

        /// <summary>
        /// Muestra en el título de la ventana el nombre completo y el rol del usuario que inició sesión.
        /// </summary>
        public void ActualizarInformacionUsuario()
        {
            if (SesionActual.EstaAutenticado)
            {
                this.Text = $"BlockBuster - Sistema Principal | Usuario: {SesionActual.NombreCompleto} ({SesionActual.NombreUsuario}) | Rol: {SesionActual.Rol}";
            }
            else
            {
                this.Text = "BlockBuster - Sistema Principal | Sesión no iniciada";
            }
        }

        /// <summary>
        /// Aplica la autorización y permisos según el rol del usuario utilizando PermisosService.
        /// </summary>
        public void AplicarPermisos()
        {
            // Opciones del menú según permisos del rol
            compraToolStripMenuItem.Enabled = PermisosService.PuedeRealizarCompras();
            ventaToolStripMenuItem.Enabled = PermisosService.PuedeRealizarVentas();
            rentaToolStripMenuItem.Enabled = PermisosService.PuedeRealizarRentas();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.PuedeRealizarVentas())
            {
                MessageBox.Show("No cuenta con permisos para acceder al módulo de ventas.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmVentas frmVentas = new frmVentas();
            frmVentas.MdiParent = this;
            frmVentas.Show();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.PuedeRealizarCompras())
            {
                MessageBox.Show("No cuenta con permisos para acceder al módulo de compras.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmCompras frmCompras = new frmCompras();
            frmCompras.MdiParent = this;
            frmCompras.Show();
        }

        private void rentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!PermisosService.PuedeRealizarRentas())
            {
                MessageBox.Show("No cuenta con permisos para acceder al módulo de rentas.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmRentas frmRentas = new frmRentas();
            frmRentas.MdiParent = this;
            frmRentas.Show();
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