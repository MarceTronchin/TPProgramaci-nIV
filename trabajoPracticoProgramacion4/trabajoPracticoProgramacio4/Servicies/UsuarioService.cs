using Microsoft.EntityFrameworkCore;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Interfaz;

namespace trabajoPracticoProgramacion4.Servicies
{
    public class UsuarioService : UsuarioInterfaz
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }
        public Task DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserModel>> GetUserModels()
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetUsuarios(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                throw new Exception($"El usuario con Id: {id} ya existe");
            }

            return usuario;
        }

        public async Task PostUsuarios(DtoUsuario usuario)
        {
            try
            {
                UserModel usuarioEntity = await _context.Usuarios
                    .FirstOrDefaultAsync(p => p.Nombre == usuario.Nombre);

                if (usuarioEntity is not null)
                    throw new Exception("El nombre de usuario ya existe");

                UserModel usuario1 = new UserModel()

                {
                    User_Name = usuario.User_Name,
                    Password = usuario.Password,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    dni = usuario.dni,
                    Email = usuario.Email,
                    Estado = usuario.Estado,
                    Id_Rol = usuario.Id_Rol,
                };

                _context.Usuarios.Add(usuario1);
                await _context.SaveChangesAsync();

            
            }catch (Exception ex)
            {
                throw new Exception("El usuario no se agrego correctamente");
            }
         }
               

        public Task PutUsuario(int id, DtoUsuario usuarioDto)
        {
            throw new NotImplementedException();
        }
    }
}
