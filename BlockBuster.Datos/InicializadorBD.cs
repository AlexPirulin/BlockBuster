using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Datos
{
    /// <summary>
    /// Clase encargada de asegurar la existencia de la base de datos y sembrar datos iniciales
    /// de usuarios, clientes y artículos de prueba (Películas, Videojuegos, Consolas).
    /// </summary>
    public static class InicializadorBD
    {
        public static bool HuboErrorBD { get; private set; } = false;
        public static string UltimoErrorBD { get; private set; } = string.Empty;

        /// <summary>
        /// Inicializa la base de datos de forma segura, manejando posibles excepciones para evitar que la app se cierre.
        /// </summary>
        public static bool Inicializar()
        {
            try
            {
                HuboErrorBD = false;
                UltimoErrorBD = string.Empty;

                using (var db = new BlockBusterDbContext())
                {
                    // Asegura que la base de datos y sus tablas existan
                    db.Database.EnsureCreated();

                    // Migración ligera automática para SQLite: asegurar columna RutaImagen
                    try
                    {
                        Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(
                            db.Database, "ALTER TABLE Articulos ADD COLUMN RutaImagen TEXT NULL;");
                    }
                    catch
                    {
                        // Si ya existe la columna, SQLite arrojará excepción que se ignora de forma segura
                    }

                    // 1. Sembrar Usuarios si no existen
                    if (!db.Usuarios.Any())
                    {
                        db.Usuarios.AddRange(
                            new Usuario
                            {
                                NombreUsuario = "admin",
                                Contrasena = "admin123",
                                NombreCompleto = "Administrador del Sistema",
                                Rol = "Administrador",
                                Activo = true,
                                FechaCreacion = DateTime.Now
                            },
                            new Usuario
                            {
                                NombreUsuario = "caja",
                                Contrasena = "caja123",
                                NombreCompleto = "Cajero de Turno",
                                Rol = "Caja",
                                Activo = true,
                                FechaCreacion = DateTime.Now
                            },
                            new Usuario
                            {
                                NombreUsuario = "cliente",
                                Contrasena = "cliente123",
                                NombreCompleto = "Cliente Predeterminado",
                                Rol = "Cliente",
                                Activo = true,
                                FechaCreacion = DateTime.Now
                            }
                        );
                        db.SaveChanges();
                    }

                    // 2. Sembrar Clientes si no existen
                    if (!db.Clientes.Any())
                    {
                        db.Clientes.AddRange(
                            new Cliente
                            {
                                Nombre = "Juan",
                                Apellido = "Pérez López",
                                Telefono = "555-123-4567",
                                Email = "juan.perez@email.com",
                                Direccion = "Av. Principal #123",
                                Activo = true,
                                FechaRegistro = DateTime.Now
                            },
                            new Cliente
                            {
                                Nombre = "María",
                                Apellido = "González Díaz",
                                Telefono = "555-987-6543",
                                Email = "maria.gonzalez@email.com",
                                Direccion = "Calle Roble #45",
                                Activo = true,
                                FechaRegistro = DateTime.Now
                            },
                            new Cliente
                            {
                                Nombre = "Carlos",
                                Apellido = "Ramírez Morales",
                                Telefono = "555-333-2211",
                                Email = "carlos.ramirez@email.com",
                                Direccion = "Blvd. Independencia #880",
                                Activo = true,
                                FechaRegistro = DateTime.Now
                            }
                        );
                        db.SaveChanges();
                    }

                    // 3. Sembrar de 10 a 15 Artículos de prueba (Películas, Videojuegos y Consolas)
                    if (db.Articulos.Count() < 10)
                    {
                        // Si ya había artículos de plantilla preliminar pero eran menos de 10, completamos o agregamos los 14 artículos
                        var codigosExistentes = new HashSet<string>(db.Articulos.Select(a => a.Codigo).ToList());

                        var articulosSemilla = ObtenerArticulosSemilla();
                        foreach (var articulo in articulosSemilla)
                        {
                            if (!codigosExistentes.Contains(articulo.Codigo))
                            {
                                db.Articulos.Add(articulo);
                            }
                        }

                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                HuboErrorBD = true;
                UltimoErrorBD = ex.Message;
                // No relanzamos para evitar que la aplicación se cierre abruptamente
                return false;
            }
        }

        /// <summary>
        /// Lista de 14 artículos de prueba con películas, videojuegos y consolas.
        /// Incluye artículos con existencia en 0 para validar el estado "No disponible".
        /// </summary>
        public static List<Articulo> ObtenerArticulosSemilla()
        {
            return new List<Articulo>
            {
                // === PELÍCULAS (5) ===
                new Articulo
                {
                    Codigo = "MOV-001",
                    Titulo = "The Matrix",
                    Tipo = "Películas",
                    Genero = "Ciencia Ficción",
                    PrecioRenta = 35.00m,
                    PrecioVenta = 160.00m,
                    Stock = 5,
                    Activo = true,
                    RutaImagen = "Imagenes\\matrix.png"
                },
                new Articulo
                {
                    Codigo = "MOV-002",
                    Titulo = "Inception",
                    Tipo = "Películas",
                    Genero = "Ciencia Ficción",
                    PrecioRenta = 40.00m,
                    PrecioVenta = 180.00m,
                    Stock = 4,
                    Activo = true,
                    RutaImagen = "Imagenes\\inception.png"
                },
                new Articulo
                {
                    Codigo = "MOV-003",
                    Titulo = "Jurassic Park",
                    Tipo = "Películas",
                    Genero = "Aventura",
                    PrecioRenta = 25.00m,
                    PrecioVenta = 120.00m,
                    Stock = 8,
                    Activo = true,
                    RutaImagen = "Imagenes\\jurassic.png"
                },
                new Articulo
                {
                    Codigo = "MOV-004",
                    Titulo = "El Padrino",
                    Tipo = "Películas",
                    Genero = "Drama / Crimen",
                    PrecioRenta = 30.00m,
                    PrecioVenta = 150.00m,
                    Stock = 3,
                    Activo = true,
                    RutaImagen = "Imagenes\\padrino.png"
                },
                new Articulo
                {
                    Codigo = "MOV-005",
                    Titulo = "Spider-Man: No Way Home",
                    Tipo = "Películas",
                    Genero = "Acción / Superhéroes",
                    PrecioRenta = 45.00m,
                    PrecioVenta = 220.00m,
                    Stock = 6,
                    Activo = true,
                    RutaImagen = "Imagenes\\spiderman.png"
                },

                // === VIDEOJUEGOS (5) ===
                new Articulo
                {
                    Codigo = "GAME-001",
                    Titulo = "Super Mario Odyssey",
                    Tipo = "Videojuegos",
                    Genero = "Nintendo Switch",
                    PrecioRenta = 50.00m,
                    PrecioVenta = 899.00m,
                    Stock = 4,
                    Activo = true,
                    RutaImagen = "Imagenes\\mario.png"
                },
                new Articulo
                {
                    Codigo = "GAME-002",
                    Titulo = "The Legend of Zelda: Tears of the Kingdom",
                    Tipo = "Videojuegos",
                    Genero = "Nintendo Switch",
                    PrecioRenta = 60.00m,
                    PrecioVenta = 1199.00m,
                    Stock = 5,
                    Activo = true,
                    RutaImagen = "Imagenes\\zelda.png"
                },
                new Articulo
                {
                    Codigo = "GAME-003",
                    Titulo = "God of War Ragnarök",
                    Tipo = "Videojuegos",
                    Genero = "PlayStation 5",
                    PrecioRenta = 55.00m,
                    PrecioVenta = 1099.00m,
                    Stock = 3,
                    Activo = true,
                    RutaImagen = "Imagenes\\gow.png"
                },
                new Articulo
                {
                    Codigo = "GAME-004",
                    Titulo = "Halo Infinite",
                    Tipo = "Videojuegos",
                    Genero = "Xbox Series X",
                    PrecioRenta = 45.00m,
                    PrecioVenta = 799.00m,
                    Stock = 6,
                    Activo = true,
                    RutaImagen = "Imagenes\\halo.png"
                },
                new Articulo
                {
                    Codigo = "GAME-005",
                    Titulo = "Grand Theft Auto V",
                    Tipo = "Videojuegos",
                    Genero = "Multiplataforma",
                    PrecioRenta = 40.00m,
                    PrecioVenta = 650.00m,
                    Stock = 7,
                    Activo = true,
                    RutaImagen = "Imagenes\\gta5.png"
                },

                // === CONSOLAS (4) ===
                new Articulo
                {
                    Codigo = "CONS-001",
                    Titulo = "PlayStation 5 Slim 1TB",
                    Tipo = "Consolas",
                    Genero = "Sony",
                    PrecioRenta = 250.00m,
                    PrecioVenta = 9999.00m,
                    Stock = 2,
                    Activo = true,
                    RutaImagen = "Imagenes\\ps5.png"
                },
                new Articulo
                {
                    Codigo = "CONS-002",
                    Titulo = "Xbox Series X 1TB",
                    Tipo = "Consolas",
                    Genero = "Microsoft",
                    PrecioRenta = 250.00m,
                    PrecioVenta = 9899.00m,
                    Stock = 3,
                    Activo = true,
                    RutaImagen = "Imagenes\\xbox.png"
                },
                new Articulo
                {
                    Codigo = "CONS-003",
                    Titulo = "Nintendo Switch OLED 64GB",
                    Tipo = "Consolas",
                    Genero = "Nintendo",
                    PrecioRenta = 180.00m,
                    PrecioVenta = 6499.00m,
                    Stock = 4,
                    Activo = true,
                    RutaImagen = "Imagenes\\switch.png"
                },
                new Articulo
                {
                    Codigo = "CONS-004",
                    Titulo = "PlayStation 4 Pro 1TB (Agotado)",
                    Tipo = "Consolas",
                    Genero = "Sony",
                    PrecioRenta = 120.00m,
                    PrecioVenta = 4999.00m,
                    Stock = 0, // Existencia en 0: debe marcarse como "No disponible"
                    Activo = true,
                    RutaImagen = "Imagenes\\ps4.png"
                }
            };
        }
    }
}

