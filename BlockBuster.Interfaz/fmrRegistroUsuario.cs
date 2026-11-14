using BlockBuster.Datos.Entidades;
using BlockBuster.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockBuster.Interfaz
{
    public partial class fmrRegistroUsuario : Form
    {
        public fmrRegistroUsuario()
        {
            InitializeComponent();
        }

        private void fmrRegistroUsuario_Load(object sender, EventArgs e)
        {/*
            if (SesionActual.EstaAutenticado)
            {
                lblInfoUsuario.Text = $"Usuario: {SesionActual.NombreCompleto} | Rol: {SesionActual.Rol}";
            }*/
        }

        private void CargarUsuarios()
        {/*
            try
            {
                List<Usuario> usuarios = _usuarioService.ObtenerTodos();
                dgvUsuarios.DataSource = usuarios;
                //modificar informacion para usuarios
                if (dgvUsuarios.Columns.Count > 0)
                {
                    dgvUsuarios.Columns["IdCliente"].HeaderText = "ID";
                    dgvUsuarios.Columns["IdCliente"].Width = 50;
                    dgvUsuarios.Columns["Nombre"].HeaderText = "Nombre";
                    dgvUsuarios.Columns["Apellido"].HeaderText = "Apellido";
                    dgvUsuarios.Columns["Telefono"].HeaderText = "Teléfono";
                    dgvUsuarios.Columns["Email"].HeaderText = "Correo";
                    dgvUsuarios.Columns["Direccion"].HeaderText = "Dirección";

                    if (dgvUsuarios.Columns.Contains("Activo"))
                        dgvUsuarios.Columns["Activo"].Visible = false;
                    if (dgvUsuarios.Columns.Contains("FechaRegistro"))
                        dgvUsuarios.Columns["FechaRegistro"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la lista de clientes: " + ex.Message,
                    "Error de Base de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }*/
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {/*
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El nombre del cliente es obligatorio.",
                    "Campo Requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            Cliente nuevoCliente = new Cliente
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            string mensajeError;
            bool resultado = _clienteService.Guardar(nuevoCliente, out mensajeError);

            if (resultado)
            {
                MessageBox.Show(
                    "Cliente registrado exitosamente.",
                    "Registro Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarClientes();
            }
            else
            {
                MessageBox.Show(
                    mensajeError,
                    "Error al Registrar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } */
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //limpiar formulario

        }
    }
}
