using System.Configuration;
using Microsoft.EntityFrameworkCore;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Datos
{
    public class BlockBusterDbContext : DbContext
    {
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

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Genero).HasMaxLength(50);
                entity.Property(e => e.PrecioRenta).HasColumnType("DECIMAL(10,2)");
                entity.Property(e => e.Stock).IsRequired();
            });
        }
    }
}
