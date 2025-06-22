public class ArticuloService : IArticulo
{
    private readonly ApplicationDbContext _context;
    public ArticuloService(ApplicationDbContext context)
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
            NombreArticulo = articuloDTO.NombreArticulo,
            DescripcionArticulo = articuloDTO.DescripcionArticulo,
            Estado = articuloDTO.Estado,
            Precio = articuloDTO.Precio
        };
        _context.Articulos.Add(articulo);
        await _context.SaveChangesAsync();
    }
    public async Task PutArticulo(int id, ArticuloDTO articuloDTO)
    {
        var articulo = await _context.Articulos.FindAsync(id);
        if (articulo != null)
        {
            articulo.NombreArticulo = articuloDTO.NombreArticulo;
            articulo.DescripcionArticulo = articuloDTO.DescripcionArticulo;
            articulo.Estado = articuloDTO.Estado;
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
}