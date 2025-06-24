using Microsoft.EntityFrameworkCore;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacion4.Servicies
{
    public class ReporteService : IReporteService
    {
        private readonly AppDbContext _context;

        public ReporteService(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<List<ReporteCuponUsoDto>> ObtenerCuponesMasUsados()
        {
            return await _context.CuponesHistorial
                .GroupBy(h => new { h.Id_Cupon, h.NroCupon, h.Cupon.Nombre })
                .Select(g => new ReporteCuponUsoDto
                {
                    NroCupon = g.Key.NroCupon,
                    NombreCupon = g.Key.Nombre,
                    CantidadUsos = g.Count()
                })
                .OrderByDescending(r => r.CantidadUsos)
                .ToListAsync();
        }

        
        public async Task<List<ReporteCuponReclamoDto>> ObtenerCuponesMasReclamados()
        {
            return await _context.CuponesClientes
                .Include(c => c.Cupon)
                .GroupBy(c => new { c.NroCupon, c.Cupon.Nombre })
                .Select(g => new ReporteCuponReclamoDto
                {
                    NroCupon = g.Key.NroCupon,
                    NombreCupon = g.Key.Nombre,
                    CantidadReclamoss = g.Count()
                })
                .OrderByDescending(r => r.CantidadReclamoss)
                .ToListAsync();
        }

        
        public async Task<List<CuponHistorialModel>> CuponesUsadosEntre(DateTime desde, DateTime hasta)
        {
            return await _context.CuponesHistorial
                .Include(h => h.Cupon)
                .Where(h => h.FechaUso >= desde && h.FechaUso <= hasta)
                .OrderBy(h => h.FechaUso)
                .ToListAsync();
        }

        
        public async Task<List<ReporteArticuloDto>> ObtenerArticulosMasUsados()
        {
            return await _context.CuponesDetalles
                .Include(d => d.Articulo)
                .GroupBy(d => new { d.IdArticulo, d.Articulo.NombreArticulo })
                .Select(g => new ReporteArticuloDto
                {
                    Id_articulo = g.Key.IdArticulo,
                    NombreArticulo = g.Key.NombreArticulo,
                    Sumatoria = g.Count()
                })
                .OrderByDescending(r => r.Sumatoria)
                .ToListAsync();
        }

        public Task<List<ReporteCuponUsoDto>> GetCuponesMasUsados()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReporteCuponReclamoDto>> GetCuponesMasReclamados()
        {
            throw new NotImplementedException();
        }

        public Task<List<CuponHistorialModel>> ObtenerHistorialCuponesPorUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReporteArticuloDto>> GetArticulosMasUsados()
        {
            throw new NotImplementedException();
        }
    }
}