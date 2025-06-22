using trabajoPracticoProgramacion4.DTOs;
namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface IAuthService
    {
        // Este método intentará loguear al usuario y devolverá el token JWT si las credenciales son válidas.
        Task<string> Login(LoginDto loginDto);

    }
}
