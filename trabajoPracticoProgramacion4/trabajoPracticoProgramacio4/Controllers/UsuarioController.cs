using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.Models;  
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.Servicies;

namespace trabajoPracticoProgramacion4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UsuarioInterfaz Iusuario;
        public UsuarioController(AppDbContext context, UsuarioInterfaz iusuario)
        {
            _context = context;
            Iusuario = iusuario;
        }

        // GET: api/Usuario
        // Este endpoint obtiene todos los usuarios.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsuarios()
        {
            // Opcional: Incluir el rol del usuario si es necesario para la respuesta
            // return await _context.Usuarios.Include(u => u.Rol).ToListAsync();
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        // Este endpoint obtiene un usuario por su Id_Usuario. (listo)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            try
            {
                UserModel usuario3 = await Iusuario.GetUsuarios(id);
                return Ok(usuario3);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Usuario/5
        // Este endpoint actualiza un usuario existente.
        // Recibe un DtoUsuario para la actualización.
        // Aquí deberías añadir lógica de autorización para que un usuario solo pueda actualizarse a sí mismo
        // o que un administrador pueda actualizar a cualquier usuario.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, DtoUsuario usuarioDto)
        {
           
            var usuarioExistente = await _context.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado para actualizar.");
            }

            // Actualizar las propiedades del usuario existente con los datos del DTO
            usuarioExistente.User_Name = usuarioDto.User_Name;
            // IMPORTANTE: NO HASHEAR LA CONTRASEÑA DE NUEVO SI NO SE CAMBIÓ O SI EL PUT ES PARA OTROS CAMPOS.
            // Si el DtoUsuario incluye la contraseña, se debe manejar cuidadosamente.
            // Si la contraseña no se envía o es vacía, no la actualices.
            // Si se envía, hasheala. Para simplificar, asumimos que si se envía, se hashea de nuevo.
            if (!string.IsNullOrWhiteSpace(usuarioDto.Password))
            {
                usuarioExistente.Password = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Password);
            }

            usuarioExistente.Nombre = usuarioDto.Nombre;
            usuarioExistente.Apellido = usuarioDto.Apellido;
            usuarioExistente.dni = usuarioDto.dni;
            usuarioExistente.Email = usuarioDto.Email;
            usuarioExistente.Estado = usuarioDto.Estado;
            usuarioExistente.Id_Rol = usuarioDto.Id_Rol; // Cuidado: Solo admins deberían poder cambiar esto.

            _context.Entry(usuarioExistente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Manejar si el usuario ya no existe o hubo un conflicto de concurrencia
                if (!UsuarioExists(id))
                {
                    return NotFound("Usuario no encontrado después de intentar actualizar.");
                }
                else
                {
                    throw; // Re-lanza la excepción si es otro tipo de problema
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el usuario: {ex.Message}");
            }

            return NoContent(); // 204 No Content - Indica que la operación fue exitosa sin contenido para devolver.
        }

        // DELETE: api/Usuario/5
        // Este endpoint elimina un usuario por su Id_Usuario.
        // Aquí deberías añadir autorización para que solo los administradores puedan eliminar usuarios.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuario no encontrado para eliminar.");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }

        // Método auxiliar para verificar si un usuario existe
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id_Usuario == id);
        }


        //Listo
        [HttpPost]
        public async Task<IActionResult> PostUsuario(DtoUsuario usuariodto)
        {
            try
            {
                if (usuariodto == null)
                    return BadRequest("Complete los campos");

                  await Iusuario.PostUsuarios(usuariodto);

                return Ok(new
                {
                    Mensaje = "Se dio de alta el usuario",
                    
                });


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}