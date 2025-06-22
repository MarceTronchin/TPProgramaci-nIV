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
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost("register")] // Ruta: api/Usuario/register
        [AllowAnonymous] // Permite el acceso sin autenticación
        public async Task<IActionResult> RegisterUser([FromBody] DtoUsuario registroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newUser = await Iusuario.RegisterUserAsync(registroDto); 
                return CreatedAtAction(nameof(GetUsuario), new { id = newUser.Id_Usuario }, newUser);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ya está registrado") || ex.Message.Contains("rol 'Cliente' no se encontró"))
                {
                    return Conflict(ex.Message);
                }
                return StatusCode(500, $"Error interno del servidor al registrar el usuario: {ex.Message}");
            }
        }

        // GET: api/Usuario
        // Este endpoint obtiene todos los usuarios.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> GetUsuarios()
        {
            try
            {
                // La llamada al servicio ya devuelve List<UsuarioResponseDto>
                var usuarios = await Iusuario.GetTodosUsuarios();
                return Ok(usuarios); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al obtener usuarios: {ex.Message}");
            }
        }

        // GET: api/Usuario/5
        // Este endpoint obtiene un usuario por su Id_Usuario. (listo)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            try
            {
                // La llamada al servicio ya devuelve UsuarioResponseDto
                var usuario = await Iusuario.GetUsuariosPorId(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no encontrado"))
                {
                    return NotFound(ex.Message);
                }
                return BadRequest($"Error al obtener el usuario: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, DtoUsuario usuarioDto)
        {
           
            var usuarioExistente = await _context.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado para actualizar.");
            }

            
            usuarioExistente.User_Name = usuarioDto.User_Name;
            
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

        private bool UsuarioExists(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                
                await Iusuario.DeleteUsuario(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                // Manejo de errores desde el servicio
                if (ex.Message.Contains("no encontrado"))
                {
                    return NotFound(ex.Message); // 404 Not Found si el usuario no existe
                }
                return BadRequest($"Error al eliminar el usuario: {ex.Message}"); // 400 Bad Request para otros errores
            }
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