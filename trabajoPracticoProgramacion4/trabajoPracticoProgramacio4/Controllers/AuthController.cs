using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace trabajoPracticoProgramacio4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config; 

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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

            }catch (Exception ex)
            {
                return BadRequest(new
                {
                    Mensaje = "Error al loguearse",
                    Error = ex.Message  
                });
            }
               

            }
        }

        


        }







    

