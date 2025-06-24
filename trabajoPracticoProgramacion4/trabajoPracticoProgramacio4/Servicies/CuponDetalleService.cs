using Microsoft.EntityFrameworkCore;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Interfaz;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CuponDetalleService : CuponDetalleInterfaz
{
    private readonly AppDbContext _context;

    public CuponDetalleService(AppDbContext context)
    {
        _context = context;
    }

    // Obtiene todos los detalles de un cupón (por Id_Cupon)
    public async Task<List<CuponDetalle>> GetDetallePorId(int Id_Cupon)
    {
        return await _context.CuponesDetalles
            .Where(cd => cd.Id_Cupon == Id_Cupon)
            .ToListAsync();
    }

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

    public async Task DeleteDetalleAsync(int Id_Cupon, int IdArticulo)
    {
        var detalle = await _context.CuponesDetalles
            .FirstOrDefaultAsync(cd => cd.Id_Cupon == Id_Cupon && cd.IdArticulo == IdArticulo);

        if (detalle == null)
            throw new Exception("Detalle de cupón no encontrado.");

        _context.CuponesDetalles.Remove(detalle);
        await _context.SaveChangesAsync();
    }
}

