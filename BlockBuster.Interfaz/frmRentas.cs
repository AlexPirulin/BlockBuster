using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmRentas : Form
    {
        public string Operacion { get; set; } = "Renta";
        public string Categoria { get; set; } = "Películas";

        public frmRentas()
        {
            InitializeComponent();
        }

        public frmRentas(string operacion, string categoria) : this()
        {
            Operacion = operacion ?? "Renta";
            Categoria = categoria ?? "Películas";
        }

        private void frmRentas_Load(object sender, EventArgs e)
        {
            ActualizarVista();
        }

        private void ActualizarVista()
        {
            lblOperacionCategoria.Text = $"MÓDULO DE {Operacion.ToUpper()}: {Categoria.ToUpper()}";
            this.Text = $"BlockBuster - {Operacion} de {Categoria}";
            lblMensajeContenido.Text = $"Catálogo de {Categoria} disponible para la operación de {Operacion}.";

            if (SesionActual.EstaAutenticado)
            {
                lblUsuarioSesion.Text = $"Usuario: {SesionActual.NombreCompleto} ({SesionActual.NombreUsuario}) | Rol: {SesionActual.Rol}";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
