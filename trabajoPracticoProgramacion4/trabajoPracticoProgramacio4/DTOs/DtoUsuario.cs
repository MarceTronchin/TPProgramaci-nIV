using System.ComponentModel.DataAnnotations;

namespace trabajoPracticoProgramacion4.DTOs
{
    public class DtoUsuario
    {
        [Required]
        public string User_Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string dni { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool Estado { get; set; } = true;
        [Required]
        public int Id_Rol { get; set; }
    }
}
