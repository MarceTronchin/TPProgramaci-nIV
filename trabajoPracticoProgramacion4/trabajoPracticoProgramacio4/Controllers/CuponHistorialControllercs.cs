using Microsoft.AspNetCore.Mvc;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.Servicies;

namespace trabajoPracticoProgramacion4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuponHistorialController : ControllerBase
    {
        private readonly ICuponHistorialServices _cuponHistorialService;

        public CuponHistorialController(ICuponHistorialServices cuponHistorialService)
        {
            _cuponHistorialService = cuponHistorialService;
        }

        // POST: api/CuponHistorial
        [HttpPost]
        public async Task<IActionResult> RegistrarUso([FromBody] CuponHistorialDto dto)
        {
            try
            {
                await _cuponHistorialService.RegistrarUsoCupon(dto);
                return Ok(new { mensaje = "Uso de cupón registrado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // GET: api/CuponHistorial/{idUsuario}
        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> VerHistorial(int idUsuario)
        {
            var historial = await _cuponHistorialService.ObtenerHistorialPorUsuario(idUsuario);
            return Ok(historial);
        }
    }
}