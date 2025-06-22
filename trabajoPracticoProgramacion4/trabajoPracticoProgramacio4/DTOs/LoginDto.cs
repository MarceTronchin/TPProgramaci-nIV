using System.ComponentModel.DataAnnotations;
namespace trabajoPracticoProgramacion4.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; }
    }
}
