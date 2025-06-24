using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;

namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface UsuarioInterfaz
    {
        Task<List<UsuarioResponseDto>> GetTodosUsuarios();

        Task<UsuarioResponseDto> GetUsuariosPorId(int id);

        Task PutUsuario(int id, string nombre);

        Task DeleteUsuario(int id );

        Task CreateUserByAdminAsync(RegistroUsuarioDTO createUserDto, int roleId);

        Task<UsuarioResponseDto> RegisterUserAsync(RegistroUsuarioDTO createUserDto);

    }
}
