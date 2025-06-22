using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.Models;
using Org.BouncyCastle.Crypto.Generators;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.Servicies;
using Microsoft.AspNetCore.Authorization;
using trabajoPracticoProgramacion4.DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace trabajoPracticoProgramacio4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config; //
        private readonly IAuthService _authService;
        public AuthController(AppDbContext context, IConfiguration config , IAuthService authService) //
        {
            _context = context;
            _config = config;
            _authService = authService;
        }

        [HttpPost("login")] // Ruta: /api/Auth/login
        [AllowAnonymous] // Indica que este endpoint no requiere autenticación
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            // Verifica las validaciones del DTO (ej. si User_Name y Password son Required)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve los errores de validación
            }

            try
            {
                // Llama al servicio de autenticación para intentar el login y obtener el token
                string token = await _authService.Login(loginDto);
                // Si todo es exitoso, devuelve un HTTP 200 OK con el token
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                // Si el login falla (ej. usuario/contraseña incorrectos), el servicio lanzará una excepción.
                // Devolvemos un 401 Unauthorized por seguridad (no damos detalles específicos del error).
                return Unauthorized(new { Message = ex.Message });
            }
        }


        [HttpPost] // LOGIN 

        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                var usuarioEntity = await _context.Usuarios
                    .Include(rol => rol.Rol)
                    .Where(usuario => usuario.User_Name == loginModel.User
                                   && usuario.Password == loginModel.Password)
                    .FirstOrDefaultAsync();


                if (usuarioEntity is null)
                    return NotFound("Credenciales Invalidas");

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, usuarioEntity.User_Name),
                     new Claim(ClaimTypes.Role, usuarioEntity.Rol.Nombre)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    Mensaje = "Login Correcto",
                    Token = tokenString,
                    Vencimiento = DateTime.Now.AddHours(1),
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Mensaje = "Error al loguearse",
                    Error = ex.Message
                });
            }


        }


        [HttpPost("register")] // REGISTRO DE USUARIO
        public async Task<IActionResult> Register(RegistroUsuarioDTO userDTO)
        {
            try
            {
                var usuarioExistente = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.User_Name == userDTO.User_Name);
                if (usuarioExistente != null)
                {
                    return BadRequest("El nombre de usuario ya está en uso.");
                }
                var nuevoUsuario = new UserModel
                {
                    User_Name = userDTO.User_Name,
                    Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password), // Encriptar la contraseña

                    Nombre = userDTO.Nombre,
                    Apellido = userDTO.Apellido,
                    dni = userDTO.Dni,
                    Email = userDTO.Email,
                    Estado = true,
                    Id_Rol = 2 // 2 por defecto - Rol de Cliente
                };

                // Agrega el nuevo usuario a la base de datos
                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();
                return Ok("Usuario registrado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Mensaje = "Error al registrar el usuario",
                    Error = ex.Message
                });
            }
        }
    }
}