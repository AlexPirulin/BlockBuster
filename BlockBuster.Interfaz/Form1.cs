using System;
using System.Windows.Forms;
using BlockBuster.Logica;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Interfaz
{
    public partial class form1 : Form
    {
        private readonly AuthService _authService;

        public form1()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Asigna el botón Aceptar como botón predeterminado al presionar Enter
            this.AcceptButton = this.BtnAceptar;

            // Enfoca el campo de usuario al abrir la ventana
            this.ActiveControl = this.txtUsuario;
        }

        /// <summary>
        /// Limpia las cajas de texto de credenciales para un nuevo inicio de sesión.
        /// </summary>
        public void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtUsuario.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContraseña.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show(
                    "Por favor, ingrese el nombre de usuario.",
                    "Campo Requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show(
                    "Por favor, ingrese la contraseña.",
                    "Campo Requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return;
            }

            // Uso de AuthService con método Login(usuario, password)
            Usuario usuarioAutenticado = _authService.Login(usuario, contrasena);

            if (usuarioAutenticado != null)
            {
                MessageBox.Show(
                    $"¡Bienvenido(a), {SesionActual.NombreCompleto}!\nRol: {SesionActual.Rol}",
                    "Inicio de Sesión Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Cierra el login; Program.cs abre la ventana principal
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos, o la cuenta se encuentra inactiva.",
                    "Acceso Denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtContraseña.Clear();
                txtContraseña.Focus();
            }
        }
    }
}