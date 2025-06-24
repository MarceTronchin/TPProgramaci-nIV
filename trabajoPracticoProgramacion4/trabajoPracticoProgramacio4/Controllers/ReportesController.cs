using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacion4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Auditor")]
    public class ReportesController : ControllerBase
    {
        private readonly IReporteService _reporteService;

        public ReportesController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        // GET: api/Reportes/mas-usados
        [HttpGet("mas-usados")]
        public async Task<ActionResult<List<ReporteCuponUsoDto>>> GetCuponesMasUsados()
        {
            var result = await _reporteService.GetCuponesMasUsados();
            return Ok(result);
        }

        // GET: api/Reportes/mas-reclamados
        [HttpGet("mas-reclamados")]
        public async Task<ActionResult<List<ReporteCuponReclamoDto>>> GetCuponesMasReclamados()
        {
            var result = await _reporteService.GetCuponesMasReclamados();
            return Ok(result);
        }

        // GET: api/Reportes/usados-rango
        [HttpGet("usados-rango")]
        public async Task<ActionResult<List<CuponHistorialModel>>> GetUsadosEnRango([FromQuery] DateTime desde, [FromQuery] DateTime hasta)
        {
            var result = await _reporteService.ObtenerHistorialCuponesPorUsuario(0); 
            var filtrados = result.Where(h => h.FechaUso >= desde && h.FechaUso <= hasta).ToList();
            return Ok(filtrados);
        }

        // GET: api/Reportes/articulos-mas-usados
        [HttpGet("articulos-mas-usados")]
        public async Task<ActionResult<List<ReporteArticuloDto>>> GetArticulosMasUsados()
        {
            var result = await _reporteService.GetArticulosMasUsados();
            return Ok(result);
        }
    }
}