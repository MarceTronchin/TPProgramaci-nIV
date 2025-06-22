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

        public async Task<List<UsuarioResponseDto>> GetTodosUsuarios()
        {
            var usuarios = await _context.Usuarios
                                         .Include(u => u.Rol) // Esto es importante para el RolNombre
                                         .ToListAsync();
            return usuarios.Select(u => new UsuarioResponseDto
            {
                Id_Usuario = u.Id_Usuario,
                User_Name = u.User_Name,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Dni = u.dni, // Asegúrate de que el mapeo de 'dni' sea correcto
                Email = u.Email,
                // Telefono ya lo eliminamos del DTO
                Estado = u.Estado,
                Id_Rol = u.Id_Rol,
                RolNombre = u.Rol?.Nombre // Obtiene el nombre del rol
            }).ToList();

        }


        public async Task<UsuarioResponseDto> GetUsuariosPorId(int id)
        {
            var usuario = await _context.Usuarios
                                        .Include(u => u.Rol) // Esto es importante para el RolNombre
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

        public Task PostUsuarios(DtoUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task PutUsuario(int id, DtoUsuario usuarioDto)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioResponseDto> RegisterUserAsync(DtoUsuario registroDto) // Usamos DtoUsuario
        {
            // --- 1. Validar Unicidad de User_Name y Email ---
            // Buscamos si ya existe un usuario con el mismo User_Name o Email.
            var existingUser = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.User_Name == registroDto.User_Name || u.Email == registroDto.Email);

            if (existingUser != null)
            {
                if (existingUser.User_Name == registroDto.User_Name)
                    throw new Exception("El nombre de usuario ya está registrado.");
                if (existingUser.Email == registroDto.Email)
                    throw new Exception("El correo electrónico ya está registrado.");
            }

            // --- 2. Hashear la Contraseña ---
            // 🔴 ¡IMPORTANTE! Aquí es donde hasheamos la contraseña antes de guardarla.
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registroDto.Password);

            // --- 3. Asignar el Rol por Defecto ("Cliente") ---
            // La consigna dice que cualquier persona que se registre debe tener el rol "Cliente".
            // Buscamos el ID de este rol en la base de datos.
            var clienteRol = await _context.Roles.FirstOrDefaultAsync(r => r.Nombre == "Cliente");
            if (clienteRol == null)
            {
                // Si el rol 'Cliente' no existe en la DB, es un error de configuración.
                throw new Exception("Error de configuración: El rol 'Cliente' no se encontró en la base de datos. Asegúrate de crearlo.");
            }

            // --- 4. Crear la Entidad UserModel para guardar en la DB ---
            var newUser = new UserModel
            {
                User_Name = registroDto.User_Name,
                Password = hashedPassword, // <-- Guardamos la contraseña HASHEADA
                Nombre = registroDto.Nombre,
                Apellido = registroDto.Apellido,
                dni = registroDto.dni,     // <-- Asegúrate de que tu modelo tiene 'dni' en minúscula
                Email = registroDto.Email,
                // Telefono ya lo eliminamos
                Estado = true,             // <-- Por defecto, el usuario está activo al registrarse
                Id_Rol = clienteRol.Id_Rol // <-- Asignamos el ID del rol "Cliente"
            };

            _context.Usuarios.Add(newUser);
            await _context.SaveChangesAsync();

            // Opcional: Recargar el usuario con la información del rol para el DTO de respuesta
            // Esto asegura que `newUser.Rol` no sea nulo al mapear a `RolNombre`.
            await _context.Entry(newUser).Reference(u => u.Rol).LoadAsync();

            // --- 5. Mapear y Devolver el UsuarioResponseDto del nuevo usuario ---
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

    }
} 
        