using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; 
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims; 
using System.Text; 
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacio4.Models; 
using BCrypt.Net; 
using System; 

namespace trabajoPracticoProgramacion4.Servicies
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration; 

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
       
            var user = await _context.Usuarios
                                     .Include(u => u.Rol) 
                                     .SingleOrDefaultAsync(u => u.User_Name == loginDto.User_Name);

        
            if (user == null || !user.Estado)
            {
                throw new Exception("Usuario o contraseña incorrectos, o usuario inactivo.");
            }

           
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                throw new Exception("Usuario o contraseña incorrectos.");
            }


            var tokenHandler = new JwtSecurityTokenHandler();
        
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        
        
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id_Usuario.ToString()), 
                new Claim(ClaimTypes.Name, user.User_Name), 
                new Claim(ClaimTypes.Role, user.Rol?.Nombre ?? "Cliente") 
            };

            // Creamos una descripción del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), // La identidad del sujeto (usuario)
                Expires = DateTime.UtcNow.AddHours(1), // El token expira en 1 hora (puedes ajustar este tiempo)
                // Credenciales para firmar el token, usando tu clave secreta y el algoritmo HMAC SHA256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Creamos y escribimos el token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); // Devolver el token como string
        }
    }
}
