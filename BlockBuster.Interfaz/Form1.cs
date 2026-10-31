using System;
using System.Windows.Forms;
using BlockBuster.Logica;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Interfaz
{
    public partial class form1 : Form
    {
        private readonly PeliculaLogica _peliculaLogica;

        public form1()
        {
            InitializeComponent();
            _peliculaLogica = new PeliculaLogica();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ejemplo de uso de la capa lógica desde la interfaz:
            // CargarPeliculas();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            frmPrincipal frmPrincipal = new frmPrincipal();
            frmPrincipal.Show();
            this.Hide();
        }

        /*
        // Ejemplo de método para listar datos en un DataGridView:
        private void CargarPeliculas()
        {
            try
            {
                // La interfaz le pide los datos a la capa lógica
                dataGridView1.DataSource = _peliculaLogica.ObtenerPeliculas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */
    }
}
