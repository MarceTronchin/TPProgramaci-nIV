using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using trabajoPracticoProgramacion4.Models;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.DTOs;


[ApiController]
[Route("api/[controller]")]
public class ArticuloController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ArticuloInterfaz Iarticulo;

    public ArticuloController(AppDbContext context, ArticuloInterfaz iArticulo)
    {
        _context = context;
        IArticulo = iArticulo;
    }

    //POST: api/Articulo 
    // Este endpoint CARGA un nuevo artículo -NO CLIENTE!!
    [HttpPost]
    [Authorize(Roles != "Cliente")]
    public async Task<IActionResult> PostArticulo(ArticuloDTO articuloDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var articulo = new ArticuloModel
        {
            Nombre = articuloDTO.Nombre,
            Descripcion = articuloDTO.Descripcion,
            Precio = articuloDTO.Precio,
            Cantidad = articuloDTO.Cantidad
        };

        _context.Articulos.Add(articulo);
        await _context.SaveChangesAsync();

        return Ok (new {mensaje = "Artículo creado correctamente.", articulo });
        }
        


    // GET: api/Articulo
    // Este endpoint obtiene TODOS los artículos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArticuloModel>>> GetArticulos()
    {
        return await _context.Articulos.ToListAsync();
    }


    // GET: api/Articulo
    // Este endpoint obtiene UN ARTICULO POR ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticulo(int id)
    {
        try
        {
            ArticuloModel articulo = await Iarticulo.GetArticulos(id);
            return Ok(articulo);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    // PUT: api/Articulo
    // Este endpoint actualiza un articulo existente
    // Recibe un DtoArticulo para la actualización
    [HttpPut("{id}")]
    [Authorize(Roles != "Cliente")]
    public async Task<IActionResult> PutArticulo(int id, ArticuloDTO articuloDTO)
    {

        var articuloYaExiste = await _context.Articulos.FindAsync(id);

        if (articuloYaExiste == null)
        {
            return NotFound("No existe un artículo cargado con ese ID.");
        }

        articuloYaExiste.Nombre = articuloDTO.Nombre;
        articuloYaExiste.Descripcion = articuloDTO.Descripcion;
        articuloYaExiste.Precio = articuloDTO.Precio;
        articuloYaExiste.Cantidad = articuloDTO.Cantidad;

        await _context.SaveChangesAsync();
        return Ok(new { mensaje = "Artículo actualizado correctamente.", articuloYaExiste });
    }


    // DELETE: api/Articulo/{id}
    // Este endpoint ELIMINA un articulo por su ID
    // solo los ADMIN pueden
    // o AUDITOR o si hubiera EMPLEADO????????????????????????     CHEQUEAR CON LOS CHICOS!!!!!!!!!!
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteArticulo(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound("Usuario no encontrado para eliminar.");
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
