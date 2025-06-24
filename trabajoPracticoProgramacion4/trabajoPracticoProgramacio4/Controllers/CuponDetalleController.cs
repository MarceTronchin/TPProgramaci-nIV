using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Interfaz;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace trabajoPracticoProgramacion4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuponDetalleController : ControllerBase
    {
        private readonly CuponDetalleInterfaz _cuponDetalleService;

        public CuponDetalleController(CuponDetalleInterfaz cuponDetalleService)
        {
            _cuponDetalleService = cuponDetalleService;
        }


        // GET: api/CuponDetalle/5
        [HttpGet("{Id_Cupon}")]
        public async Task<ActionResult<List<CuponDetalle>>> GetDetallePorId(int Id_Cupon)
        {
            var detalles = await _cuponDetalleService.GetDetallePorId(Id_Cupon);
            return Ok(detalles);
        }


        // PUT: api/CuponDetalle
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PutDetalle([FromBody] DtoCuponDetalle dto)
        {
            try
            {
                await _cuponDetalleService.UpdateDetalleAsync(dto);
                return Ok(new { message = "Detalle actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/CuponDetalle/5/6
        [HttpDelete("{Id_Cupon}/{IdArticulo}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteDetalleAsync(int Id_Cupon, int IdArticulo)
        {
            try
            {
                await _cuponDetalleService.DeleteDetalleAsync(Id_Cupon, IdArticulo);
                return Ok(new { message = "Detalle eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
