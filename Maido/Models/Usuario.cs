using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Maido.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Rol { get; set; }
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
        [DisplayName("Fecha de Creacion")]
        public DateOnly FechaCreacion { get; set; } = DateOnly.FromDateTime(DateTime.Today);


    }
}
