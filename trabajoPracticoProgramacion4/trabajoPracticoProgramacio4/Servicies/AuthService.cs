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
        private readonly IConfiguration _configuration; // Para acceder a la clave JWT de appsettings.json

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            // 1. Buscar al usuario por User_Name (nombre de usuario)
            // Incluimos el Rol para poder añadirlo como claim en el token
            var user = await _context.Usuarios
                                     .Include(u => u.Rol) // Cargar la información del rol asociado
                                     .SingleOrDefaultAsync(u => u.User_Name == loginDto.User_Name);

            // 2. Verificar si el usuario existe y si su estado es activo
            if (user == null || !user.Estado)
            {
                throw new Exception("Usuario o contraseña incorrectos, o usuario inactivo.");
            }

            // 3. Verificar la contraseña hasheada
            // BCrypt.Net.BCrypt.Verify(textoPlano, hashAlmacenado) compara la contraseña plana
            // recibida con el hash almacenado en la DB.
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                throw new Exception("Usuario o contraseña incorrectos.");
            }

            // 4. Generar el Token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            // Obtenemos la clave secreta de la configuración (appsettings.json)
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            // Definimos los "claims" (declaraciones) que se incluirán en el token.
            // Estos claims pueden ser la identidad del usuario, su rol, etc.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id_Usuario.ToString()), // ID único del usuario
                new Claim(ClaimTypes.Name, user.User_Name), // Nombre de usuario
                new Claim(ClaimTypes.Role, user.Rol?.Nombre ?? "Cliente") // Nombre del rol del usuario (ej. "Admin", "Cliente")
                                                                         // Si el rol es null por alguna razón, por defecto es "Cliente"
                // Puedes añadir más claims si necesitas más información en el token, ej: Email
                // new Claim(ClaimTypes.Email, user.Email)
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
