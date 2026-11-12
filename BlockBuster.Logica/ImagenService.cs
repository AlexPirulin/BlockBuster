using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio para el manejo y almacenamiento de imágenes en la carpeta 'Imagenes'.
    /// Copia imágenes seleccionadas, devuelve la ruta relativa y carga imágenes
    /// con respaldo a una imagen por defecto si el archivo no existe.
    /// </summary>
    public static class ImagenService
    {
        private const string NombreCarpeta = "Imagenes";

        /// <summary>
        /// Obtiene la ruta física absoluta de la carpeta 'Imagenes' en el directorio de ejecución.
        /// </summary>
        public static string CarpetaImagenes
        {
            get
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string dir = Path.Combine(basePath, NombreCarpeta);
                if (!Directory.Exists(dir))
                {
                    try
                    {
                        Directory.CreateDirectory(dir);
                    }
                    catch
                    {
                        // Manejo de error si los permisos impiden la creación
                    }
                }
                return dir;
            }
        }

        /// <summary>
        /// Copia la imagen elegida a la carpeta 'Imagenes' y devuelve la ruta relativa.
        /// </summary>
        /// <param name="rutaArchivoOrigen">Ruta completa del archivo seleccionado por el usuario.</param>
        /// <returns>Ruta relativa generada (ej. "Imagenes\\art_xxx.png").</returns>
        public static string CopiarImagen(string rutaArchivoOrigen)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivoOrigen) || !File.Exists(rutaArchivoOrigen))
            {
                return string.Empty;
            }

            try
            {
                string extension = Path.GetExtension(rutaArchivoOrigen);
                if (string.IsNullOrEmpty(extension))
                {
                    extension = ".png";
                }

                string nombreArchivo = $"art_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString("N").Substring(0, 8)}{extension}";
                string rutaDestino = Path.Combine(CarpetaImagenes, nombreArchivo);

                File.Copy(rutaArchivoOrigen, rutaDestino, true);

                return Path.Combine(NombreCarpeta, nombreArchivo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al copiar la imagen a la carpeta 'Imagenes': " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Carga la imagen desde la ruta relativa guardada en RutaImagen.
        /// Si el archivo no existe o la ruta está vacía, devuelve una imagen por defecto generada.
        /// </summary>
        /// <param name="rutaImagen">Ruta relativa o absoluta de la imagen.</param>
        /// <param name="tituloFallback">Texto o título para mostrar en la imagen por defecto.</param>
        /// <returns>Instancia de Image lista para asignarse a controles PictureBox.</returns>
        public static Image CargarImagen(string rutaImagen, string tituloFallback = null)
        {
            if (!string.IsNullOrWhiteSpace(rutaImagen))
            {
                try
                {
                    string rutaCompleta = ResolverRutaCompleta(rutaImagen);

                    if (File.Exists(rutaCompleta))
                    {
                        // Se carga mediante MemoryStream para evitar bloqueos del archivo en disco
                        byte[] bytes = File.ReadAllBytes(rutaCompleta);
                        using (var ms = new MemoryStream(bytes))
                        {
                            return Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    // En caso de cualquier error de lectura, continuamos al fallback
                }
            }

            // Imagen por defecto si falta el archivo o es inválido
            return GenerarImagenPorDefecto(tituloFallback);
        }

        /// <summary>
        /// Resuelve la ruta completa a partir de una ruta que puede ser absoluta o relativa.
        /// </summary>
        private static string ResolverRutaCompleta(string ruta)
        {
            if (Path.IsPathRooted(ruta))
            {
                return ruta;
            }

            // 1. Intentar relativo a BaseDirectory
            string candidata1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);
            if (File.Exists(candidata1)) return candidata1;

            // 2. Intentar dentro de la carpeta Imagenes
            string nombreSolo = Path.GetFileName(ruta);
            string candidata2 = Path.Combine(CarpetaImagenes, nombreSolo);
            if (File.Exists(candidata2)) return candidata2;

            return candidata1;
        }

        /// <summary>
        /// Genera una imagen por defecto con diseño corporativo Blockbuster (Azul y Dorado)
        /// cuando no exista imagen en la ruta especificada.
        /// </summary>
        public static Image GenerarImagenPorDefecto(string texto = "BLOCKBUSTER")
        {
            int ancho = 240;
            int alto = 320;
            Bitmap bmp = new Bitmap(ancho, alto);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Fondo degradado azul corporativo
                using (LinearGradientBrush bg = new LinearGradientBrush(
                    new Rectangle(0, 0, ancho, alto),
                    Color.FromArgb(20, 35, 65),
                    Color.FromArgb(10, 20, 40),
                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(bg, 0, 0, ancho, alto);
                }

                // Borde dorado
                using (Pen pen = new Pen(Color.FromArgb(255, 204, 0), 3))
                {
                    g.DrawRectangle(pen, 5, 5, ancho - 10, alto - 10);
                }

                // Ícono central representativo
                using (Font iconFont = new Font("Segoe UI Emoji", 36, FontStyle.Bold))
                using (Brush iconBrush = new SolidBrush(Color.FromArgb(255, 204, 0)))
                {
                    string icon = "🎬 / 🎮";
                    SizeF iconSize = g.MeasureString(icon, iconFont);
                    g.DrawString(icon, iconFont, iconBrush, (ancho - iconSize.Width) / 2, 80);
                }

                // Título o nombre del artículo
                string txt = string.IsNullOrWhiteSpace(texto) ? "BLOCKBUSTER" : texto;
                using (Font font = new Font("Arial Rounded MT Bold", 11, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    RectangleF rectTexto = new RectangleF(15, 170, ancho - 30, 80);
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(txt, font, textBrush, rectTexto, sf);
                }

                // Subtexto "Sin Imagen"
                using (Font subFont = new Font("Arial", 8.5f, FontStyle.Italic))
                using (Brush subBrush = new SolidBrush(Color.LightGray))
                {
                    RectangleF rectSub = new RectangleF(15, 270, ancho - 30, 25);
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString("(Imagen por Defecto)", subFont, subBrush, rectSub, sf);
                }
            }

            return bmp;
        }

        /// <summary>
        /// Genera las imágenes de prueba para los artículos semilla de la base de datos
        /// y las guarda en la carpeta 'Imagenes'.
        /// </summary>
        public static void AsegurarImagenesSemilla()
        {
            try
            {
                string carpeta = CarpetaImagenes;

                var items = new (string archivo, string titulo, string tipo, Color color1, Color color2)[]
                {
                    ("matrix.png", "The Matrix", "🎬 Película", Color.FromArgb(10, 50, 20), Color.FromArgb(0, 20, 10)),
                    ("inception.png", "Inception", "🎬 Película", Color.FromArgb(20, 30, 60), Color.FromArgb(10, 15, 35)),
                    ("jurassic.png", "Jurassic Park", "🎬 Película", Color.FromArgb(60, 30, 10), Color.FromArgb(30, 15, 5)),
                    ("padrino.png", "El Padrino", "🎬 Película", Color.FromArgb(40, 10, 10), Color.FromArgb(20, 5, 5)),
                    ("spiderman.png", "Spider-Man", "🎬 Película", Color.FromArgb(70, 10, 20), Color.FromArgb(10, 30, 70)),
                    ("mario.png", "Super Mario", "🎮 Videojuego", Color.FromArgb(80, 20, 20), Color.FromArgb(20, 40, 80)),
                    ("zelda.png", "Zelda TotK", "🎮 Videojuego", Color.FromArgb(20, 70, 50), Color.FromArgb(10, 35, 25)),
                    ("gow.png", "God of War", "🎮 Videojuego", Color.FromArgb(40, 40, 60), Color.FromArgb(20, 20, 30)),
                    ("halo.png", "Halo Infinite", "🎮 Videojuego", Color.FromArgb(30, 60, 30), Color.FromArgb(15, 30, 15)),
                    ("gta5.png", "GTA V", "🎮 Videojuego", Color.FromArgb(20, 50, 70), Color.FromArgb(10, 25, 40)),
                    ("ps5.png", "PS5 Slim", "🕹️ Consola", Color.FromArgb(15, 25, 60), Color.FromArgb(230, 230, 240)),
                    ("xbox.png", "Xbox Series X", "🕹️ Consola", Color.FromArgb(10, 50, 20), Color.FromArgb(15, 15, 15)),
                    ("switch.png", "Switch OLED", "🕹️ Consola", Color.FromArgb(80, 15, 15), Color.FromArgb(230, 230, 230)),
                    ("ps4.png", "PS4 Pro", "🕹️ Consola", Color.FromArgb(10, 20, 50), Color.FromArgb(5, 10, 25))
                };

                foreach (var item in items)
                {
                    string rutaArchivo = Path.Combine(carpeta, item.archivo);
                    if (!File.Exists(rutaArchivo))
                    {
                        using (Bitmap bmp = new Bitmap(240, 320))
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.SmoothingMode = SmoothingMode.AntiAlias;

                            using (LinearGradientBrush bg = new LinearGradientBrush(
                                new Rectangle(0, 0, 240, 320), item.color1, item.color2, LinearGradientMode.Vertical))
                            {
                                g.FillRectangle(bg, 0, 0, 240, 320);
                            }

                            using (Pen p = new Pen(Color.FromArgb(255, 204, 0), 3))
                            {
                                g.DrawRectangle(p, 5, 5, 230, 310);
                            }

                            using (Font catFont = new Font("Arial Rounded MT Bold", 10))
                            using (Brush catBrush = new SolidBrush(Color.Gold))
                            {
                                g.DrawString(item.tipo, catFont, catBrush, 15, 20);
                            }

                            using (Font titleFont = new Font("Arial Rounded MT Bold", 13, FontStyle.Bold))
                            using (Brush tBrush = new SolidBrush(Color.White))
                            {
                                RectangleF r = new RectangleF(15, 100, 210, 100);
                                StringFormat sf = new StringFormat
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center
                                };
                                g.DrawString(item.titulo, titleFont, tBrush, r, sf);
                            }

                            using (Font brandFont = new Font("Arial Rounded MT Bold", 9))
                            using (Brush bBrush = new SolidBrush(Color.LightCyan))
                            {
                                g.DrawString("BLOCKBUSTER", brandFont, bBrush, 65, 280);
                            }

                            bmp.Save(rutaArchivo, ImageFormat.Png);
                        }
                    }
                }
            }
            catch
            {
                // Silencioso si ocurre error en creación preliminar de imágenes de prueba
            }
        }
    }
}

