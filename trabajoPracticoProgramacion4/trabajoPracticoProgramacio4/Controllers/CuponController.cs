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
        private readonly ICuponCliente _cuponClienteService;
        private readonly IEmailService _emailService;
        public CuponController(CuponInterfaz cuponService, ICuponCliente cuponClienteService, IEmailService email)
        {
            _cuponService = cuponService;
            _cuponClienteService = cuponClienteService;
            _emailService = email;
        }

        // GET: api/Cupon
        [HttpGet]
        public async Task<ActionResult<List<CuponModel>>> GetAllCupones()
        {
            var cupones = await _cuponService.GetAllCupones();
            return Ok(cupones);
        }

        // GET: api/Cupon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuponModel>> GetCuponPorId(int id)
        {
            var cupon = await _cuponService.GetCuponPorId(id);
            if (cupon == null)
                return NotFound();
            return Ok(cupon);
        }

        [HttpGet("{nroCupon}/detalles")]
        public async Task<ActionResult<List<CuponDetalle>>> GetDetallesPorCupon(string nroCupon)
        {
            var detalles = await _cuponService.GetDetallesPorCupon(nroCupon);
            return Ok(detalles);
        }

        [HttpGet("activos-vigentes")]
        public async Task<ActionResult<List<CuponModel>>> GetCuponesActivosYVigentes()
        {
            var cupones = await _cuponService.GetCuponesActivosYVigentes();
            return Ok(cupones);
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

        // PUT: api/Cupon/5
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

        // DELETE: api/Cupon/5
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





        ////Cupones y clientes

        [HttpGet("disponibles/{idUsuario}")]
        public async Task<IActionResult> GetCuponesDisponibles(int idUsuario)
        {
            var cuponesDisponibles = await _cuponClienteService.VerCuponesDisponiblesTodos(idUsuario);
            return Ok(cuponesDisponibles);
        }


        [HttpGet("cuponesDelCliente/{idUsuario}")]
        public async Task<IActionResult> VerCuponesReclamados(int idUsuario)
        {
            var cuponesReclamados = await _cuponClienteService.VerCuponesReclamados(idUsuario);
            return Ok(cuponesReclamados);
        }



        [HttpPost("reclamar")]
        public async Task<IActionResult> ReclamarCupon([FromBody] ReclamarCuponDto reclamaCupon)
        {
            try
            {
                await _cuponClienteService.ReclamarCupon(reclamaCupon.IdUsuario, reclamaCupon.NroCupon);

                // Simulacion envío de email
                var destinatario = "cliente@example.com";
                var asunto = "Reclamo de Cupón";
                var cuerpo = $"Has reclamado el cupón {reclamaCupon.NroCupon}. ¡Aprovechalo antes de su vencimiento!";

                _emailService.EnviarCorreoSimulado(destinatario, asunto, cuerpo);

                return Ok(new { message = "Cupón reclamado correctamente (correo enviado)" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }







    }
}