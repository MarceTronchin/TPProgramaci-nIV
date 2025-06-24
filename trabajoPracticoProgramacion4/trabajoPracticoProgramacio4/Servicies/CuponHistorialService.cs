using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.Models;
using Microsoft.EntityFrameworkCore;

namespace trabajoPracticoProgramacion4.Servicies
{
    public class CuponHistorialService : ICuponHistorialServices

    {
        private readonly AppDbContext _context;

        public CuponHistorialService(AppDbContext context)
        {
            _context = context;
        }

        // Registrar el uso de un cupón por parte de un usuario
        public async Task RegistrarUsoCupon(CuponHistorialDto dto)
        {
            // Validar que el cupón exista y esté activo
            var cupon = await _context.Cupones
                .FirstOrDefaultAsync(c => c.Id_Cupon == dto.Id_Cupon && c.Activo);

            if (cupon == null)
                throw new Exception("Cupón no válido o inactivo.");

            // Validar que el usuario tenga asignado ese cupón
            var reclamado = await _context.CuponesClientes
                .AnyAsync(cc => cc.Id_Usuario == dto.Id_Usuario && cc.NroCupon == dto.NroCupon);

            if (!reclamado)
                throw new Exception("Este cupón no ha sido reclamado por el usuario.");

            // Verificar que no se haya usado ya (si tu lógica requiere un solo uso)
            var yaUsado = await _context.CuponesHistorial
                .AnyAsync(h => h.Id_Cupon == dto.Id_Cupon && h.Id_Usuario == dto.Id_Usuario);

            if (yaUsado)
                throw new Exception("Este cupón ya fue utilizado por el usuario.");

            var historial = new CuponHistorialModel
            {
                Id_Cupon = dto.Id_Cupon,
                NroCupon = dto.NroCupon,
                Id_Usuario = dto.Id_Usuario,
                FechaUso = DateTime.Now
            };

            _context.CuponesHistorial.Add(historial);
            await _context.SaveChangesAsync();
        }

        // Obtener historial de uso por usuario
        public async Task<List<CuponHistorialModel>> ObtenerHistorialPorUsuario(int idUsuario)
        {
            return await _context.CuponesHistorial
                .Include(h => h.Cupon)
                .Where(h => h.Id_Usuario == idUsuario)
                .ToListAsync();
        }


    }
}