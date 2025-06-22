using Microsoft.EntityFrameworkCore;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.Models;

public class ArticuloService : IArticulo
{
    private readonly AppDbContext _context;

    public ArticuloService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<ArticuloModel>> GetAllArticulos()
    {
        return await _context.Articulos.ToListAsync();
    }
    public async Task<ArticuloModel> GetArticuloPorID(int id)
    {
        return await _context.Articulos.FindAsync(id);
    }
    public async Task PostArticulo(ArticuloDTO articuloDTO)
    {
        var articulo = new ArticuloModel
        {
            NombreArticulo = articuloDTO.Nombre,
            DescripcionArticulo = articuloDTO.Descripcion,
            //Estado = articuloDTO.
            Precio = articuloDTO.Precio,
        };
        _context.Articulos.Add(articulo);
        await _context.SaveChangesAsync();
    }
    public async Task PutArticulo(int id, ArticuloDTO articuloDTO)
    {
        var articulo = await _context.Articulos.FindAsync(id);
        if (articulo != null)
        {
            articulo.NombreArticulo = articuloDTO.Nombre;
            articulo.DescripcionArticulo = articuloDTO.Descripcion;
           // articulo.Estado = articuloDTO.Estado;
            articulo.Precio = articuloDTO.Precio;
            _context.Articulos.Update(articulo);
            await _context.SaveChangesAsync();
        }
    }
    public async Task DeleteArticuloo(int id)
    {
        var articulo = await _context.Articulos.FindAsync(id);
        if (articulo != null)
        {
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
        }
    }

    Task<List<ArticuloModel>> IArticulo.GetAllArticulos()
    {
        throw new NotImplementedException();
    }

    Task<ArticuloModel> IArticulo.GetArticuloPorID(int id)
    {
        throw new NotImplementedException();
    }
}