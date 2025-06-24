using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using trabajoPracticoProgramacio4.Models;

namespace trabajoPracticoProgramacion4.Servicies
{
    public class CuponClienteService : ICuponCliente
    {
        private readonly AppDbContext _context;

        public CuponClienteService(AppDbContext context)
        {
            _context = context;
        }

        // cupones disponibles 
        public async Task<List<CuponModel>> VerCuponesDisponiblesPorUsuario(int idUsuario)
        {
            var reclamados = await _context.CuponesClientes
                .Where(cc => cc.Id_Usuario == idUsuario)
                .Select(cc => cc.NroCupon)
                .ToListAsync();

            return await _context.Cupones
                .Where(ct => ct.Activo &&
                             DateTime.Now >= ct.FechaInicio &&
                             DateTime.Now <= ct.FechaFin &&
                             !reclamados.Contains(ct.NroCupon))
                .ToListAsync();
        }

        // reclamar un cupon
        public async Task ReclamarCupon(int idUsuario, string nroCupon)
        {
            var cupon = await _context.Cupones.FindAsync(nroCupon);

            if (cupon == null || !cupon.Activo || cupon.FechaFin < DateTime.Now)
                throw new Exception("Este cupón ya no es válido.");

            var yaReclamado = await _context.CuponesClientes
                .FirstOrDefaultAsync(cc => cc.NroCupon == nroCupon && cc.Id_Usuario == idUsuario);

            if (yaReclamado != null)
                throw new Exception("Este cupón ya ha sido utilizado.");

            var cuponReclamado = new CuponClienteModel
            {
                NroCupon = nroCupon,
                Id_Usuario = idUsuario,
                FechaAsignado = DateTime.Now
            };

            _context.CuponesClientes.Add(cuponReclamado);
            await _context.SaveChangesAsync();
        }

        // ver cupones reclamados 
        public async Task<List<CuponModel>> VerCuponesCliente(int idUsuario)
        {
            return await _context.CuponesClientes
                .Include(cc => cc.Cupon)
                .Where(cc => cc.Id_Usuario == idUsuario && cc.Cupon.FechaFin >= DateTime.Now)
                .Select(cc => cc.Cupon)
                .ToListAsync();
        }

        public Task<List<CuponModel>> VerCuponesDisponiblesTodos(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<CuponModel>> VerCuponesReclamados(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}