using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;

namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface UsuarioInterfaz
    {
        Task<List<UsuarioResponseDto>> GetTodosUsuarios();

        Task<UsuarioResponseDto> GetUsuariosPorId(int id);
        Task PostUsuarios( UsuarioUpdateDto usuario ); //registro usuario

        Task PutUsuario(int id, UsuarioUpdateDto usuarioDto);

        Task DeleteUsuario(int id );

        Task<UsuarioResponseDto> RegisterUserAsync(UsuarioUpdateDto registroDto);
        Task RegisterUserAsync(UsuarioUpdateDto registroDto, string v);
    }
}
