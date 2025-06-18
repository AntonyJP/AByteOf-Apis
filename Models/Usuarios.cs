using System.ComponentModel.DataAnnotations;

namespace AByteOf熊猫Apis.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required, MaxLength(75)]
        public string Nombre { get; set; }
        [Required, EmailAddress]
        public string Correo { get; set; }
        [Required, MinLength(6)]
        public string Contrasena { get; set; }
    }
}
