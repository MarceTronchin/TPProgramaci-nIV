using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using trabajoPracticoProgramacion4.Models;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.DTOs;

namespace trabajoPracticoProgramacion4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticulo _iArticulo;

        public ArticuloController(IArticulo iArticulo)
        {
            _iArticulo = iArticulo;
        }

        // POST: api/Articulo
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostArticulo([FromBody] ArticuloDTO articuloDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _iArticulo.PostArticulo(articuloDTO);

            return Ok(new { mensaje = "Art�culo creado correctamente." });
        }

        // GET: api/Articulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloModel>>> GetArticulos()
        {
            var articulos = await _iArticulo.GetAllArticulos();
            return Ok(articulos);
        }

        // GET: api/Articulo/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticulo(int id)
        {
            var articulo = await _iArticulo.GetArticuloPorID(id);
            if (articulo == null)
                return NotFound("Art�culo no encontrado.");

            return Ok(articulo);
        }

        // PUT: api/Articulo/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutArticulo(int id, [FromBody] ArticuloDTO articuloDTO)
        {
            var articuloExistente = await _iArticulo.GetArticuloPorID(id);
            if (articuloExistente == null)
                return NotFound("No existe un art�culo con ese ID.");

            await _iArticulo.PutArticulo(id, articuloDTO);

            return Ok(new { mensaje = "Art�culo actualizado correctamente." });
        }

        // DELETE: api/Articulo/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _iArticulo.GetArticuloPorID(id);
            if (articulo == null)
                return NotFound("Art�culo no encontrado para eliminar.");

            await _iArticulo.DeleteArticulo(id);
            return Ok(new { mensaje = "Art�culo eliminado correctamente." });
        }
    }
}