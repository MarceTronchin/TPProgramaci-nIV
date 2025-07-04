﻿using Microsoft.EntityFrameworkCore;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.Context;
using trabajoPracticoProgramacion4.Interfaz;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Helpers;

public class CuponService : CuponInterfaz
{
    private readonly AppDbContext _context;
    public CuponService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<CuponModel>> GetAllCupones()
    {
        return await _context.Cupones.ToListAsync();
    }
    public async Task<CuponModel> GetCuponPorId(int id)
    {
        return await _context.Cupones.FindAsync(id);
    }
    public async Task PostCupon(DtoCupon cuponDTO)
    {
        var cuponTipo = await _context.TiposCupones.FindAsync(cuponDTO.Id_Tipo_Cupon);

        if (cuponTipo == null)
        {
            throw new Exception("tipo inexistente");
        }
        if (cuponTipo.Nombre == "Por porcentaje" && cuponDTO.PorcentajeDto == null)
        {
            throw new Exception("Es obligatorio ingresar el porcentaje de descuento");
        }


        if (cuponTipo.Nombre == "Por importe" && cuponDTO.ImportePromo == null)
        {
            throw new Exception("Debe ingresar el importe correspondiente");
        }

        string NroCuponGenNue = cuponDTO.NroCupon ?? GeneradorCupon.GenerarCupon();
        while (await _context.Cupones.AnyAsync(c => c.NroCupon == NroCuponGenNue))
        { //NRO CUPON GENERADO NUEVO
            NroCuponGenNue = GeneradorCupon.GenerarCupon();
        }
        var cupon = new CuponModel
        {
            Nombre = cuponDTO.Nombre,
            Descripcion = cuponDTO.Descripcion,
            PorcentajeDTO = cuponDTO.PorcentajeDto ?? 0,
            ImportePromo = cuponDTO.ImportePromo ?? 0,
            FechaInicio = cuponDTO.FechaInicio,
            FechaFin = cuponDTO.FechaFin,
            Id_Tipo_Cupon = cuponDTO.Id_Tipo_Cupon,
            Activo = cuponDTO.Activo,
            NroCupon = NroCuponGenNue,
        };
        _context.Cupones.Add(cupon);
        await _context.SaveChangesAsync();
    }
    public async Task PutCupon(int id, DtoCupon cuponDTO)
    {
        var cupon = await _context.Cupones.FindAsync(id);
        try
        {
            if (cupon != null)
            {
                cupon.Nombre = cuponDTO.Nombre;
                cupon.Descripcion = cuponDTO.Descripcion;
                cupon.PorcentajeDTO = cuponDTO.PorcentajeDto ?? 0;
                cupon.ImportePromo = cuponDTO.ImportePromo ?? 0;
                cupon.FechaInicio = cuponDTO.FechaInicio;
                cupon.FechaFin = cuponDTO.FechaFin;
                cupon.Id_Tipo_Cupon = cuponDTO.Id_Tipo_Cupon;
                cupon.Activo = cuponDTO.Activo;

                _context.Cupones.Update(cupon);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex) { throw new Exception("Cupon no encontrado."); }
    }
    public async Task DeleteCupon(int id)
    {
        var articulo = await _context.Cupones.FindAsync(id);
        if (articulo != null)
        {
            _context.Cupones.Remove(articulo);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<CuponDetalle>> GetDetallesPorCupon(string NroCupon)
    {
        var cupon = await _context.Cupones.FirstOrDefaultAsync(c => c.NroCupon == NroCupon);
        if (cupon == null)
            return new List<CuponDetalle>();

        return await _context.CuponesDetalles
            .Where(cd => cd.Id_Cupon == cupon.Id_Cupon)
            .ToListAsync();
    }
    public async Task<List<CuponModel>> GetCuponesActivosYVigentes()
    {
        var hoy = DateTime.Today;
        return await _context.Cupones
            .Where(c => c.Activo && c.FechaInicio.Date <= hoy && c.FechaFin.Date >= hoy)
            .ToListAsync();

    }
}

