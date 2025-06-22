using System.ComponentModel.DataAnnotations;
namespace trabajoPracticoProgramacion4.DTOs
{
    public class UsuarioResponseDto
    {
        public int Id_Usuario { get; set; }
        public string User_Name { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
        public int Id_Rol { get; set; }
        public string? RolNombre { get; set; }
    }
}
