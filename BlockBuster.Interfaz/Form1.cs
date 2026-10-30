using System;
using System.Windows.Forms;
using BlockBuster.Logica;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Interfaz
{
    public partial class Form1 : Form
    {
        private readonly PeliculaLogica _peliculaLogica;

        public Form1()
        {
            InitializeComponent();
            _peliculaLogica = new PeliculaLogica();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ejemplo de uso de la capa lógica desde la interfaz:
            // CargarPeliculas();
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
