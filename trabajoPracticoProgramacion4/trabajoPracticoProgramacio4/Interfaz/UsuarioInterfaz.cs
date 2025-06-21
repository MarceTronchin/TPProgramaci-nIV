using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;

namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface UsuarioInterfaz
    {
        Task<List<UserModel>> GetUserModels();

        Task<UserModel> GetUsuarios(int id);
        Task PostUsuarios( DtoUsuario usuario );

        Task PutUsuario(int id, DtoUsuario usuarioDto);

        Task DeleteUsuario(int id );
    }
}
