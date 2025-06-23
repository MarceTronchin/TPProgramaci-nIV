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
        public AuthController(AppDbContext context, IConfiguration config, IAuthService authService) //
        {
            _context = context;
            _config = config;
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            // Verifica las validaciones del DTO (ej. si User_Name y Password son Required)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                string token = await _authService.Login(loginDto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {

                return Unauthorized(new { Message = ex.Message });
            }
        }
    }
}