using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlockBuster.Datos.Entidades
{
    [Table("Peliculas")]
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPelicula { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [StringLength(50)]
        public string Genero { get; set; }

        public decimal PrecioRenta { get; set; }

        public int Stock { get; set; }

        public Pelicula()
        {
        }

        public Pelicula(int idPelicula, string titulo, string genero, decimal precioRenta, int stock)
        {
            IdPelicula = idPelicula;
            Titulo = titulo;
            Genero = genero;
            PrecioRenta = precioRenta;
            Stock = stock;
        }
    }
}
