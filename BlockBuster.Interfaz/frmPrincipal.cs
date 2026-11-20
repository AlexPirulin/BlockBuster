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
            btnCatalogo.Visible = true;

            // Compras pendientes exclusivo para Administrador y Caja
            btnComprasPendientes.Visible = PermisosService.EsAdministrador() || PermisosService.EsCajero();

            // Mostrar u ocultar opciones según PermisosService
            // Inventario y Gestión de Usuarios son exclusivos para Administrador
            btnInventario.Visible = PermisosService.PuedeEditarInventario();
            btnUsuarios.Visible = PermisosService.PuedeGestionarUsuarios();

            // Registro de Clientes disponible para Administrador y Caja
            btnClientes.Visible = PermisosService.EsAdministrador() || PermisosService.EsCajero();
        }

        #region Eventos de Botones Principales

        private void btnRenta_Click(object sender, EventArgs e)
        {
            AbrirVentanaMdi(frmRentas.ObtenerInstancia());
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            AbrirVentanaMdi(frmVentas.ObtenerInstancia());
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            AbrirVentanaMdi(frmCompras.ObtenerInstancia());
        }

        private void btnComprasPendientes_Click(object sender, EventArgs e)
        {
            if (!PermisosService.EsAdministrador() && !PermisosService.EsCajero())
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no cuenta con permisos para revisar compras pendientes.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            AbrirVentanaMdi(frmComprasPendientes.ObtenerInstancia());
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            AbrirVentanaMdi(frmSeleccionCategoria.ObtenerInstancia("Catálogo"));
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

            AbrirVentanaMdi(frmInventario.ObtenerInstancia());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Validación de permisos en la capa lógica: Solo Admin puede gestionar usuarios
            if (!PermisosService.PuedeGestionarUsuarios())
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no cuenta con permisos para gestionar usuarios del sistema.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            AbrirVentanaMdi(fmrRegistroUsuario.ObtenerInstancia());
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

            AbrirVentanaMdi(frmRegistroCliente.ObtenerInstancia());
        }

        #endregion

        /// <summary>
        /// Abre la ventana de selección de categoría para la operación seleccionada (Renta, Venta o Compra).
        /// Todos los roles tienen acceso y se utiliza el patrón Singleton para asegurar que no se abran
        /// múltiples opciones o instancias a la vez.
        /// </summary>
        private void EjecutarOperacion(string operacion)
        {
            AbrirVentanaMdi(frmSeleccionCategoria.ObtenerInstancia(operacion));
        }

        /// <summary>
        /// Cierra cualquier otra ventana secundaria para mantener una sola activa a la vez (Singleton)
        /// y presenta la ventana MDI solicitada en primer plano.
        /// </summary>
        private void AbrirVentanaMdi(Form ventana)
        {
            if (ventana == null) return;

            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo != ventana)
                {
                    hijo.Close();
                }
            }

            ventana.MdiParent = this;
            ventana.Show();
            ventana.BringToFront();
            ventana.Activate();
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
