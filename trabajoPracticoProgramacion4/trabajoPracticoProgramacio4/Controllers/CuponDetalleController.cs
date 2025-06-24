using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Interfaz;

namespace trabajoPracticoProgramacion4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuponDetalleController : ControllerBase
    {
        private readonly CuponInterfaz _cuponService;

        public CuponDetalleController(CuponInterfaz cuponService)
        {
            _cuponService = cuponService;
        }

        // GET: api/Cupon
        [HttpGet("{nroCupon:int}/{idArticulo:int}")]
        public async Task<ActionResult<CuponDetalle>> Get(string nroCupon, int idArticulo)
        {
            var detalle = await _cuponService.GetDetalleAsync(nroCupon, idArticulo);
            if (detalle == null)
                return NotFound(new { error = "Detalle de cupón no encontrado." });
            return Ok(detalle);
        }

        // POST: api/Cupon
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PostCupon([FromBody] DtoCupon cuponDto)
        {
            try
            {
                await _cuponService.PostCupon(cuponDto);
                return Ok(new { message = "Cupón creado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/Cupon
        [HttpPut("{string nroCupon}/{idArticulo:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PutCupon(string nroCupon, int idArticulo, [FromBody] DtoCupon cuponDto)
        {
            try
            {
                await _cuponService.PutCupon(string nroCupon, int idArticulo, cuponDto);
                return Ok(new { message = "Cupón actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/Cupon
        [HttpDelete("{idCupon:int}/{idArticulo:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteCupon(string nroCupon, int idArticulo)
        {
            try
            {
                await _cuponService.DeleteCupon(string nroCupon, idArticulo);
                return Ok(new { message = "Cupón eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
