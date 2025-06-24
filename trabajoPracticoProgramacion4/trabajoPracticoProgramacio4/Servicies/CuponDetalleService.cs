using Microsoft.EntityFrameworkCore;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.DTOs;

public class CuponDetalleService
{
    private readonly AppDbContext _context;

    public CuponDetalleService(AppDbContext context)
    {
        _context = context;
    }

    //Lista todos los detalles de cupones
    public async Task<List<CuponDetalle>> GetAllDetallesAsync()
    {
        return await _context.CuponesDetalles.ToListAsync();
    }

    //Obtiene un detalle por id de cupón e id de artículo (clave compuesta)
    public async Task<CuponDetalle?> GetDetalleAsync(int idCupon, int idArticulo)
    {
        return await _context.CuponesDetalles
            .FirstOrDefaultAsync(cd => cd.Id_Cupon == idCupon && cd.IdArticulo == idArticulo);
    }

    //Crea un nuevo detalle de cupón
    public async Task AddDetalleAsync(DtoCuponDetalle dto)
    {
        // Validación
        if (dto.Cantidad <= 0)
            throw new Exception("La cantidad debe ser mayor a 0.");

        var detalle = new CuponDetalle
        {
            Id_Cupon = dto.Id_Cupon,
            IdArticulo = dto.IdArticulo,
            Cantidad = dto.Cantidad
        };

        _context.CuponesDetalles.Add(detalle);
        await _context.SaveChangesAsync();
    }

    //Actualiza un detalle (sólo la cantidad, ya que la PK compuesta no debería cambiar)
    public async Task UpdateDetalleAsync(DtoCuponDetalle dto)
    {
        var detalle = await _context.CuponesDetalles
            .FirstOrDefaultAsync(cd => cd.Id_Cupon == dto.Id_Cupon && cd.IdArticulo == dto.IdArticulo);

        if (detalle == null)
            throw new Exception("Detalle de cupón no encontrado.");

        detalle.Cantidad = dto.Cantidad;
        _context.CuponesDetalles.Update(detalle);
        await _context.SaveChangesAsync();
    }

    //Elimina un detalle por clave compuesta
    public async Task DeleteDetalleAsync(int idCupon, int idArticulo)
    {
        var detalle = await _context.CuponesDetalles
            .FirstOrDefaultAsync(cd => cd.Id_Cupon == idCupon && cd.IdArticulo == idArticulo);

        if (detalle == null)
            throw new Exception("Detalle de cupón no encontrado.");

        _context.CuponesDetalles.Remove(detalle);
        await _context.SaveChangesAsync();
    }
}
