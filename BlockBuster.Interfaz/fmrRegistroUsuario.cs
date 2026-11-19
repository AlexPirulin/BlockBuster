using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class fmrRegistroUsuario : Form
    {
        private static fmrRegistroUsuario _instancia;
        private readonly UsuarioService _usuarioService;
        private int _usuarioSeleccionadoId = 0;

        /// <summary>
        /// Patrón Singleton: Retorna la instancia única activa de la ventana de gestión de usuarios.
        /// </summary>
        public static fmrRegistroUsuario ObtenerInstancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
            {
                _instancia = new fmrRegistroUsuario();
            }
            else
            {
                if (_instancia.WindowState == FormWindowState.Minimized)
                    _instancia.WindowState = FormWindowState.Normal;
                _instancia.BringToFront();
                _instancia.Activate();
            }
            return _instancia;
        }

        public static fmrRegistroUsuario Instancia => _instancia;

        public fmrRegistroUsuario()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
        }

        private void fmrRegistroUsuario_Load(object sender, EventArgs e)
        {
            // 1. Verificación de permisos en la capa lógica: Solo Admin puede gestionar usuarios
            if (!PermisosService.PuedeGestionarUsuarios())
            {
                MessageBox.Show(
                    $"Su rol actual '{SesionActual.Rol}' no tiene permisos para acceder a la administración de usuarios.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            if (SesionActual.EstaAutenticado)
            {
                lblInfoUsuario.Text = $"Administrador: {SesionActual.NombreCompleto} | Rol: {SesionActual.Rol}";
            }

            cboRol.SelectedIndex = 1; // "Caja" por defecto
            LimpiarFormulario();
            CargarUsuarios();
        }

        /// <summary>
        /// Consulta todos los usuarios a través de UsuarioService y actualiza el DataGridView.
        /// </summary>
        public void CargarUsuarios()
        {
            try
            {
                List<Usuario> lista = _usuarioService.ObtenerTodos();

                // Filtrar por texto si el campo de búsqueda no está vacío
                string busqueda = txtBuscar.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(busqueda))
                {
                    lista = lista.Where(u =>
                        (!string.IsNullOrEmpty(u.NombreUsuario) && u.NombreUsuario.ToLower().Contains(busqueda)) ||
                        (!string.IsNullOrEmpty(u.NombreCompleto) && u.NombreCompleto.ToLower().Contains(busqueda)) ||
                        (!string.IsNullOrEmpty(u.Rol) && u.Rol.ToLower().Contains(busqueda))
                    ).ToList();
                }

                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = lista;

                ConfigurarColumnasGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la lista de usuarios:\n" + ex.Message,
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvUsuarios.Columns.Count > 0)
            {
                if (dgvUsuarios.Columns.Contains("IdUsuario"))
                {
                    dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
                    dgvUsuarios.Columns["IdUsuario"].Width = 50;
                }

                if (dgvUsuarios.Columns.Contains("NombreUsuario"))
                {
                    dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario (Login)";
                    dgvUsuarios.Columns["NombreUsuario"].Width = 140;
                }

                if (dgvUsuarios.Columns.Contains("Contrasena"))
                {
                    dgvUsuarios.Columns["Contrasena"].Visible = false; // No mostrar contraseñas en claro en el grid
                }

                if (dgvUsuarios.Columns.Contains("NombreCompleto"))
                {
                    dgvUsuarios.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
                    dgvUsuarios.Columns["NombreCompleto"].FillWeight = 160;
                }

                if (dgvUsuarios.Columns.Contains("Rol"))
                {
                    dgvUsuarios.Columns["Rol"].HeaderText = "Rol";
                    dgvUsuarios.Columns["Rol"].Width = 110;
                }

                if (dgvUsuarios.Columns.Contains("Activo"))
                {
                    dgvUsuarios.Columns["Activo"].HeaderText = "Activo";
                    dgvUsuarios.Columns["Activo"].Width = 70;
                }

                if (dgvUsuarios.Columns.Contains("FechaCreacion"))
                {
                    dgvUsuarios.Columns["FechaCreacion"].HeaderText = "Fecha Registro";
                    dgvUsuarios.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvUsuarios.Columns["FechaCreacion"].Width = 140;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas de interfaz
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("El nombre completo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return;
            }

            if (cboRol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol para el usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRol.Focus();
                return;
            }

            string mensajeError;

            if (_usuarioSeleccionadoId == 0)
            {
                // MODO CREAR NUEVO USUARIO
                if (string.IsNullOrWhiteSpace(txtContrasena.Text))
                {
                    MessageBox.Show("La contraseña es obligatoria para un usuario nuevo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return;
                }

                Usuario nuevo = new Usuario
                {
                    NombreUsuario = txtNombreUsuario.Text.Trim(),
                    Contrasena = txtContrasena.Text.Trim(),
                    NombreCompleto = txtNombreCompleto.Text.Trim(),
                    Rol = cboRol.Text,
                    Activo = chkActivo.Checked
                };

                bool creado = _usuarioService.Crear(nuevo, out mensajeError);
                if (creado)
                {
                    MessageBox.Show(
                        $"Usuario '{nuevo.NombreUsuario}' creado exitosamente con el rol '{nuevo.Rol}'.",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show(
                        mensajeError,
                        "Error al Crear Usuario",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                // MODO EDITAR USUARIO EXISTENTE
                Usuario usuarioEditar = new Usuario
                {
                    IdUsuario = _usuarioSeleccionadoId,
                    NombreUsuario = txtNombreUsuario.Text.Trim(),
                    Contrasena = txtContrasena.Text.Trim(), // Si viene vacío, UsuarioService conserva la anterior
                    NombreCompleto = txtNombreCompleto.Text.Trim(),
                    Rol = cboRol.Text,
                    Activo = chkActivo.Checked
                };

                bool actualizado = _usuarioService.Editar(usuarioEditar, out mensajeError);
                if (actualizado)
                {
                    MessageBox.Show(
                        $"Usuario '{usuarioEditar.NombreUsuario}' actualizado exitosamente.",
                        "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show(
                        mensajeError,
                        "Error al Actualizar Usuario",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionadoId <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un usuario de la lista para desactivar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string nombre = txtNombreUsuario.Text.Trim();
            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro de que desea desactivar la cuenta del usuario '{nombre}'?",
                "Confirmar Desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string mensajeError;
                bool ok = _usuarioService.Desactivar(_usuarioSeleccionadoId, out mensajeError);
                if (ok)
                {
                    MessageBox.Show(
                        $"Usuario '{nombre}' desactivado exitosamente.",
                        "Operación Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show(
                        mensajeError,
                        "Error al Desactivar Usuario",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _usuarioSeleccionadoId = 0;
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            txtNombreCompleto.Clear();
            cboRol.SelectedIndex = 1; // "Caja"
            chkActivo.Checked = true;
            chkActivo.Enabled = true;

            lblIdInfo.Text = "Modo: Nuevo Usuario";
            btnGuardar.Text = "💾 Guardar";
            btnDesactivar.Enabled = false;

            txtNombreUsuario.Focus();
        }

        private void CargarUsuarioParaEdicion(Usuario usuario)
        {
            if (usuario == null) return;

            _usuarioSeleccionadoId = usuario.IdUsuario;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtContrasena.Clear(); // No mostrar hash o password en el input
            txtNombreCompleto.Text = usuario.NombreCompleto;

            int rolIndex = cboRol.FindStringExact(usuario.Rol);
            if (rolIndex != -1) cboRol.SelectedIndex = rolIndex;
            else cboRol.Text = usuario.Rol;

            chkActivo.Checked = usuario.Activo;
            chkActivo.Enabled = true;

            lblIdInfo.Text = $"Modo: Editando Usuario #{usuario.IdUsuario} ('{usuario.NombreUsuario}') - (Deje password en blanco para no modificarlo)";
            btnGuardar.Text = "💾 Actualizar";
            btnDesactivar.Enabled = usuario.Activo;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsuarios.SelectedRows.Count > 0)
            {
                Usuario usuario = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;
                if (usuario != null)
                {
                    CargarUsuarioParaEdicion(usuario);
                }
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                Usuario usuario = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;
                if (usuario != null)
                {
                    CargarUsuarioParaEdicion(usuario);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarUsuarios();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _instancia = null;
        }
    }
}
