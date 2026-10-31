using System;
using System.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Datos
{
    public class BlockBusterDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        public BlockBusterDbContext()
        {
        }

        public BlockBusterDbContext(DbContextOptions<BlockBusterDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = ConfigurationManager.ConnectionStrings["BlockBusterSqlite"]?.ConnectionString
                              ?? "Data Source=blockbuster.db";
                optionsBuilder.UseSqlite(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Configuración de Usuarios
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);
                entity.HasIndex(e => e.NombreUsuario).IsUnique();
                entity.Property(e => e.NombreUsuario).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Contrasena).IsRequired().HasMaxLength(100);
                entity.Property(e => e.NombreCompleto).HasMaxLength(100);
                entity.Property(e => e.Rol).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Activo).HasDefaultValue(true);

                // Datos iniciales de usuarios requeridos
                entity.HasData(
                    new Usuario
                    {
                        IdUsuario = 1,
                        NombreUsuario = "admin",
                        Contrasena = "admin123",
                        NombreCompleto = "Administrador del Sistema",
                        Rol = "Administrador",
                        Activo = true,
                        FechaCreacion = new DateTime(2026, 1, 1)
                    },
                    new Usuario
                    {
                        IdUsuario = 2,
                        NombreUsuario = "caja",
                        Contrasena = "caja123",
                        NombreCompleto = "Cajero de Turno",
                        Rol = "Caja",
                        Activo = true,
                        FechaCreacion = new DateTime(2026, 1, 1)
                    },
                    new Usuario
                    {
                        IdUsuario = 3,
                        NombreUsuario = "cliente",
                        Contrasena = "cliente123",
                        NombreCompleto = "Cliente Predeterminado",
                        Rol = "Cliente",
                        Activo = true,
                        FechaCreacion = new DateTime(2026, 1, 1)
                    }
                );
            });

            // 2. Configuración de Clientes
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).HasMaxLength(100);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Direccion).HasMaxLength(200);
                entity.Property(e => e.Activo).HasDefaultValue(true);

                entity.HasData(
                    new Cliente
                    {
                        IdCliente = 1,
                        Nombre = "Juan",
                        Apellido = "Pérez",
                        Telefono = "555-123-4567",
                        Email = "juan.perez@email.com",
                        Direccion = "Av. Principal #123",
                        Activo = true,
                        FechaRegistro = new DateTime(2026, 1, 1)
                    }
                );
            });

            // 3. Configuración de Artículos
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.IdArticulo);
                entity.Property(e => e.Codigo).HasMaxLength(30);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Tipo).HasMaxLength(50);
                entity.Property(e => e.Genero).HasMaxLength(50);
                entity.Property(e => e.PrecioRenta).HasColumnType("DECIMAL(10,2)");
                entity.Property(e => e.PrecioVenta).HasColumnType("DECIMAL(10,2)");
                entity.Property(e => e.Stock).IsRequired();
                entity.Property(e => e.Activo).HasDefaultValue(true);

                entity.HasData(
                    new Articulo
                    {
                        IdArticulo = 1,
                        Codigo = "MOV-001",
                        Titulo = "The Matrix",
                        Tipo = "Película BluRay",
                        Genero = "Ciencia Ficción",
                        PrecioRenta = 35.00m,
                        PrecioVenta = 150.00m,
                        Stock = 5,
                        Activo = true
                    },
                    new Articulo
                    {
                        IdArticulo = 2,
                        Codigo = "MOV-002",
                        Titulo = "Jurassic Park",
                        Tipo = "Película DVD",
                        Genero = "Aventura",
                        PrecioRenta = 25.00m,
                        PrecioVenta = 120.00m,
                        Stock = 8,
                        Activo = true
                    },
                    new Articulo
                    {
                        IdArticulo = 3,
                        Codigo = "GAME-001",
                        Titulo = "Super Mario Odyssey",
                        Tipo = "Videojuego",
                        Genero = "Plataformas",
                        PrecioRenta = 50.00m,
                        PrecioVenta = 899.00m,
                        Stock = 3,
                        Activo = true
                    }
                );
            });

            // 4. Configuración de Películas (retrocompatibilidad)
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Genero).HasMaxLength(50);
                entity.Property(e => e.PrecioRenta).HasColumnType("DECIMAL(10,2)");
                entity.Property(e => e.Stock).IsRequired();
            });
        }

        /// <summary>
        /// Asegura que la base de datos esté creada y los usuarios iniciales existan.
        /// </summary>
        public static void InicializarBaseDatos()
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Database.EnsureCreated();

                if (!db.Usuarios.Any())
                {
                    db.Usuarios.AddRange(
                        new Usuario { NombreUsuario = "admin", Contrasena = "admin123", NombreCompleto = "Administrador del Sistema", Rol = "Administrador", Activo = true },
                        new Usuario { NombreUsuario = "caja", Contrasena = "caja123", NombreCompleto = "Cajero de Turno", Rol = "Caja", Activo = true },
                        new Usuario { NombreUsuario = "cliente", Contrasena = "cliente123", NombreCompleto = "Cliente Predeterminado", Rol = "Cliente", Activo = true }
                    );
                    db.SaveChanges();
                }
            }
        }
    }
}
