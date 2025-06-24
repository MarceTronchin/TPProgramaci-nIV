using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Interfaz;

namespace trabajoPracticoProgramacion4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuponController : ControllerBase
    {
        private readonly CuponInterfaz _cuponService;

        public CuponController(CuponInterfaz cuponService)
        {
            _cuponService = cuponService;
        }

        // GET: api/Cupon
        [HttpGet("{nroCupon}/{idArticulo:int}")]
        public async Task<ActionResult<CuponDetalle>> Get(string nroCupon, int idArticulo)
        {
            var detalle = await _service.GetDetalleAsync(nroCupon, idArticulo);
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
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PutCupon(int id, [FromBody] DtoCupon cuponDto)
        {
            try
            {
                await _cuponService.PutCupon(id, cuponDto);
                return Ok(new { message = "Cupón actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/Cupon
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteCupon(int id)
        {
            try
            {
                await _cuponService.DeleteCupon(id);
                return Ok(new { message = "Cupón eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
