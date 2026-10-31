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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abirir formulario de ventas dentro del mdicontainer
            frmVentas frmVentas = new frmVentas();
            frmVentas.MdiParent = this;
            frmVentas.Show();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompras frmCompras = new frmCompras();
            frmCompras.MdiParent = this;
            frmCompras.Show();
        }

        private void rentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRentas frmRentas = new frmRentas();
            frmRentas.MdiParent = this;
            frmRentas.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cerrar la sesión y volver al formulario de inicio de sesión
            this.Hide();
            form1 loginForm = new form1();
            loginForm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
