using System;

namespace BlockBuster.Datos.Entidades
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public string Titulo { get; set; }
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

