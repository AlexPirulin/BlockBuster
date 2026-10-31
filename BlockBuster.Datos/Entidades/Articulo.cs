using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlockBuster.Datos.Entidades
{
    [Table("Articulos")]
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArticulo { get; set; }

        [StringLength(30)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [StringLength(50)]
        public string Tipo { get; set; }

        [StringLength(50)]
        public string Genero { get; set; }

        public decimal PrecioRenta { get; set; }

        public decimal PrecioVenta { get; set; }

        public int Stock { get; set; }

        public bool Activo { get; set; } = true;

        public Articulo()
        {
        }

        public Articulo(string codigo, string titulo, string tipo, string genero, decimal precioRenta, decimal precioVenta, int stock)
        {
            Codigo = codigo;
            Titulo = titulo;
            Tipo = tipo;
            Genero = genero;
            PrecioRenta = precioRenta;
            PrecioVenta = precioVenta;
            Stock = stock;
            Activo = true;
        }
    }
}
