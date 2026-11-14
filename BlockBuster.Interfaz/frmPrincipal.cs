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
        /// Aplica la autorización para las ventanas y botones según los métodos de PermisosService.
        /// Inventario es exclusivo para Administrador; Registro de Clientes para Admin y Caja.
        /// </summary>
        public void AplicarPermisos()
        {
            btnRenta.Enabled = true;
            btnVenta.Enabled = true;
            btnCompra.Enabled = true;

            // Mostrar u ocultar opciones según PermisosService
            btnInventario.Visible = PermisosService.PuedeEditarInventario();
            btnClientes.Visible = PermisosService.EsAdministrador() || PermisosService.EsCajero();
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

        private void btnInventario_Click(object sender, EventArgs e)
        {
            // Validación de permisos en la capa lógica
            if (!PermisosService.PuedeEditarInventario())
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no cuenta con permisos para gestionar el inventario.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Cerrar cualquier otra ventana hija para mantener una sola activa (Singleton)
            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo != frmInventario.Instancia)
                {
                    hijo.Close();
                }
            }

            frmInventario inventario = frmInventario.ObtenerInstancia();
            inventario.MdiParent = this;
            inventario.Show();
            inventario.BringToFront();
            inventario.Activate();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            // Validación de permisos en la capa lógica
            if (!PermisosService.EsAdministrador() && !PermisosService.EsCajero())
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no cuenta con permisos para gestionar clientes.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Cerrar cualquier otra ventana secundaria para mantener el espacio limpio
            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo != frmRegistroCliente.Instancia)
                {
                    hijo.Close();
                }
            }

            frmRegistroCliente clientes = frmRegistroCliente.ObtenerInstancia();
            clientes.MdiParent = this;
            clientes.Show();
            clientes.BringToFront();
            clientes.Activate();
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

        private void lblUsuarioActual_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
