using System.ComponentModel.DataAnnotations;

public class RegistroUsuarioDTO
{

    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe tener entre 3 y 50 caracteres.")]
    public string User_Name { get; set; }

    [Required(ErrorMessage = "La contrase�a es obligatoria.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "La contrase�a debe tener al menos 6 caracteres.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "La confirmaci�n de contrase�a es obligatoria.")]
    [Compare("Password", ErrorMessage = "La contrase�a y la confirmaci�n no coinciden.")]
    public string ConfirmPassword { get; set; } //Para asegurar que el usuario teclea bien la contrase�a

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    [StringLength(10, ErrorMessage = "El DNI no puede exceder los 10 caracteres.")]
    public string Dni { get; set; } 

    [Required(ErrorMessage = "El correo electr�nico es obligatorio.")]
    [EmailAddress(ErrorMessage = "Formato de correo electr�nico no v�lido.")]
    [StringLength(100, ErrorMessage = "El correo electr�nico no puede exceder los 100 caracteres.")]
    public string Email { get; set; }

    public int? Id_Rol { get; set; }


}