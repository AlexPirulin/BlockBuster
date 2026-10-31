using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlockBuster.Datos.Entidades
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Apellido { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        public bool Activo { get; set; } = true;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public Cliente()
        {
        }

        public Cliente(string nombre, string apellido, string telefono, string email, string direccion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            Activo = true;
            FechaRegistro = DateTime.Now;
        }
    }
}
