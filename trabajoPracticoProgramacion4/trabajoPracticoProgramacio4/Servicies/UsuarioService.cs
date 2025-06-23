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

        public async Task DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                throw new Exception($"Usuario con ID {id} no encontrado para eliminar.");
            }

            // Eliminación LÓGICA: marca el usuario como inactivo
            usuario.Estado = false;
            _context.Entry(usuario).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        
        public async Task<List<UsuarioResponseDto>> GetTodosUsuarios()
        {
            var usuarios = await _context.Usuarios
                                         .Include(u => u.Rol) 
                                         .ToListAsync();
            return usuarios.Select(u => new UsuarioResponseDto
            {
                Id_Usuario = u.Id_Usuario,
                User_Name = u.User_Name,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Dni = u.dni, 
                Email = u.Email,
                Estado = u.Estado,
                Id_Rol = u.Id_Rol,
                RolNombre = u.Rol?.Nombre 
            }).ToList();

        }


        public async Task<UsuarioResponseDto> GetUsuariosPorId(int id)
        {
            var usuario = await _context.Usuarios
                                        .Include(u => u.Rol) 
                                        .FirstOrDefaultAsync(u => u.Id_Usuario == id);

            if (usuario == null)
            {
                throw new Exception($"Usuario con ID {id} no encontrado.");
            }
            return new UsuarioResponseDto
            {
                Id_Usuario = usuario.Id_Usuario,
                User_Name = usuario.User_Name,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Dni = usuario.dni,
                Email = usuario.Email,
                Estado = usuario.Estado,
                Id_Rol = usuario.Id_Rol,
                RolNombre = usuario.Rol?.Nombre
            };
        }

        public async Task<UsuarioResponseDto> PostUsuarios(UsuarioUpdateDto usuario, string hashedPassword)
        {
       
            var existingUser = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.User_Name == usuario.User_Name || u.Email == usuario.Email);

            if (existingUser != null)
            {
                if (existingUser.User_Name == usuario.User_Name)
                    throw new Exception("El nombre de usuario ya está registrado.");
                if (existingUser.Email == usuario.Email)
                    throw new Exception("El correo electrónico ya está registrado.");
            }

            var clienteRol = await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == "Cliente");
            if (clienteRol == null)
            {
                throw new Exception("Error de configuración: El rol 'Cliente' no se encontró en la base de datos. Asegúrate de crearlo.");
            }

  
            var newUser = new UserModel
            {
                User_Name = usuario.User_Name,
                Password = hashedPassword, // Contraseña HASHEADA
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                dni = usuario.dni,
                Email = usuario.Email,
                Estado = true,
                Id_Rol = clienteRol.Id_Rol
            };

            _context.Usuarios.Add(newUser);
            await _context.SaveChangesAsync();

            await _context.Entry(newUser).Reference(u => u.Rol).LoadAsync();

     
            return new UsuarioResponseDto
            {
                Id_Usuario = newUser.Id_Usuario,
                User_Name = newUser.User_Name,
                Nombre = newUser.Nombre,
                Apellido = newUser.Apellido,
                Dni = newUser.dni,
                Email = newUser.Email,
                Estado = newUser.Estado,
                Id_Rol = newUser.Id_Rol,
                RolNombre = newUser.Rol?.Nombre
            };
        }

        

        public async Task PutUsuario(int id, UsuarioUpdateDto usuarioDto)
        {
            var usuarioDto1 = await _context.Usuarios.FindAsync(id);

            if (usuarioDto1 == null)
            {
                throw new Exception($"Usuario con ID {id} no encontrado para actualizar.");
            }


            if (!string.IsNullOrEmpty(usuarioDto.User_Name) && usuarioDto.User_Name != usuarioDto1.User_Name)
            {
                if (await _context.Usuarios.AnyAsync(u => u.User_Name == usuarioDto1.User_Name && u.Id_Usuario != id))
                {
                    throw new Exception("El nuevo nombre de usuario ya está en uso.");
                }
                usuarioDto.User_Name = usuarioDto.User_Name;
            }

            if (!string.IsNullOrEmpty(usuarioDto.Email) && usuarioDto.Email != usuarioDto1.Email)
            {
                if (await _context.Usuarios.AnyAsync(u => u.Email == usuarioDto.Email && u.Id_Usuario != id))
                {
                    throw new Exception("El nuevo correo electrónico ya está en uso.");
                }
                usuarioDto1.Email = usuarioDto.Email;
            }

            if (usuarioDto.Nombre != null) usuarioDto1.Nombre = usuarioDto.Nombre;
            if (usuarioDto.Apellido != null) usuarioDto1.Apellido = usuarioDto.Apellido;
            if (usuarioDto.dni != null) usuarioDto1.dni = usuarioDto.dni;
            if (usuarioDto.Email != null) usuarioDto1.Email = usuarioDto.Email;
            if (usuarioDto.Estado != true) usuarioDto1.Estado = usuarioDto.Estado;
            if (usuarioDto.Id_Rol != null) usuarioDto1.Id_Rol = usuarioDto.Id_Rol;

            await _context.SaveChangesAsync();


            // if (!string.IsNullOrEmpty(usuarioDto.Password) && !BCrypt.Net.BCrypt.Verify(usuarioDto.Password, userToUpdate.Password))
            // {
            //     usuarioDto1.Password = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Password);
            // }

            //await _context.SaveChangesAsync();
        }

        public async Task<UsuarioResponseDto> RegisterUserAsync(UsuarioUpdateDto registroDto, string hashedPassword) 
        {
           
            var existingUser = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.User_Name == registroDto.User_Name || u.Email == registroDto.Email);

            if (existingUser != null)
            {
                if (existingUser.User_Name == registroDto.User_Name)
                    throw new Exception("El nombre de usuario ya está registrado.");
                if (existingUser.Email == registroDto.Email)
                    throw new Exception("El correo electrónico ya está registrado.");
            }

            var clienteRol = await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == "Cliente");
            if (clienteRol == null)
            {
                
                throw new Exception("Error de configuración: El rol 'Cliente' no se encontró en la base de datos. Asegúrate de crearlo.");
            }

            
            var newUser = new UserModel
            {
                User_Name = registroDto.User_Name,
                Password = hashedPassword, 
                Nombre = registroDto.Nombre,
                Apellido = registroDto.Apellido,
                dni = registroDto.dni,     
                Email = registroDto.Email,
                Estado = true,             
                Id_Rol = clienteRol.Id_Rol
            };

            _context.Usuarios.Add(newUser);
            await _context.SaveChangesAsync();

      
       
            await _context.Entry(newUser).Reference(u => u.Rol).LoadAsync();

        
            return new UsuarioResponseDto
            {
                Id_Usuario = newUser.Id_Usuario,
                User_Name = newUser.User_Name,
                Nombre = newUser.Nombre,
                Apellido = newUser.Apellido,
                Dni = newUser.dni,
                Email = newUser.Email,
                Estado = newUser.Estado,
                Id_Rol = newUser.Id_Rol,
                RolNombre = newUser.Rol?.Nombre
            };
        }

        public Task<UsuarioResponseDto> RegisterUserAsync(UsuarioUpdateDto registroDto)
        {
            throw new NotImplementedException();
        }

        Task UsuarioInterfaz.PostUsuarios(UsuarioUpdateDto usuario)
        {
            throw new NotImplementedException();
        }

        Task UsuarioInterfaz.RegisterUserAsync(UsuarioUpdateDto registroDto, string v)
        {
            throw new NotImplementedException();
        }
    }
} 
        