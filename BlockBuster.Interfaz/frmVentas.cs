using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    public partial class frmVentas : Form
    {
        public string Operacion { get; set; } = "Venta";
        public string Categoria { get; set; } = "Películas";

        public frmVentas()
        {
            InitializeComponent();
        }

        public frmVentas(string operacion, string categoria) : this()
        {
            Operacion = operacion ?? "Venta";
            Categoria = categoria ?? "Películas";
        }

        private void frmVentas_Load(object sender, EventArgs e)
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
