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
        /// Aplica la autorización para las ventanas.
        /// Todos los roles tienen acceso a abrir las distintas ventanas (Renta, Venta y Compra).
        /// </summary>
        public void AplicarPermisos()
        {
            btnRenta.Enabled = true;
            btnVenta.Enabled = true;
            btnCompra.Enabled = true;
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

        /// <summary>
        /// Abre la ventana de selección de categoría para la operación seleccionada (Renta, Venta o Compra).
        /// Todos los roles tienen acceso y se utiliza el patrón Singleton para asegurar que no se abran
        /// múltiples opciones o instancias a la vez.
        /// </summary>
        private void EjecutarOperacion(string operacion)
        {
            // Cierra cualquier otra ventana secundaria para que no se puedan abrir todas las opciones a la vez
            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo != frmSeleccionCategoria.Instancia)
                {
                    hijo.Close();
                }
            }

            // Abre o enfoca la instancia única de selección de categoría (Singleton)
            frmSeleccionCategoria selector = frmSeleccionCategoria.ObtenerInstancia(operacion);
            selector.MdiParent = this;
            selector.Show();
            selector.BringToFront();
            selector.Activate();
        }

        /// <summary>
        /// Cierra la sesión activa del usuario y retorna a la pantalla de Login.
        /// </summary>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
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

                // Cierra la ventana principal; Program.cs detecta el cierre de sesión y reabre Form1
                this.Close();
            }
        }
    }
}
