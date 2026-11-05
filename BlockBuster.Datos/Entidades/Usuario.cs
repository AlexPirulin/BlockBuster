using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlockBuster.Datos.Entidades
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Contrasena { get; set; }

        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [StringLength(30)]
        public string Rol { get; set; }

        public bool Activo { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public Usuario()
        {
        }

        public Usuario(string nombreUsuario, string contrasena, string nombreCompleto, string rol)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            NombreCompleto = nombreCompleto;
            Rol = rol;
            Activo = true;
            FechaCreacion = DateTime.Now;
        }
    }
}

