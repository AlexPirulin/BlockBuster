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

            // Manejo global de excepciones para evitar cierres abruptos
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += (s, args) =>
            {
                var ex = args.ExceptionObject as Exception;
                MessageBox.Show(
                    "Ocurrió un error en el sistema:\n" + (ex?.Message ?? "Error no identificado"),
                    "BlockBuster - Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            };

            // Inicialización segura de la base de datos y de imágenes de prueba
            try
            {
                BlockBuster.Datos.InicializadorBD.Inicializar();
                BlockBuster.Logica.ImagenService.AsegurarImagenesSemilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Aviso al iniciar la base de datos:\n" + ex.Message + "\n\nLa aplicación continuará en modo seguro.",
                    "BlockBuster - Conexión de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

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