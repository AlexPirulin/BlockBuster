using System;
using System.Windows.Forms;
using BlockBuster.Logica;

namespace BlockBuster.Interfaz
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (form1 login = new form1())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }

                Application.Run(new frmPrincipal());

                // Si la sesión sigue activa, el usuario salió de la aplicación;
                // si se cerró la sesión, se vuelve a mostrar el login.
                if (SesionActual.EstaAutenticado)
                {
                    return;
                }
            }
        }
    }
}