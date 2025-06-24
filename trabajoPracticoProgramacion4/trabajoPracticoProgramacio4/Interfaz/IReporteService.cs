using trabajoPracticoProgramacion4.Models;
using trabajoPracticoProgramacion4.DTOs;

namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface IReporteService
    {
        Task <List<ReporteCuponUsoDto>> GetCuponesMasUsados();

        Task<List<ReporteCuponReclamoDto>> GetCuponesMasReclamados();

        Task <List<CuponHistorialModel>> ObtenerHistorialCuponesPorUsuario(int idUsuario);

        Task<List<ReporteArticuloDto>> GetArticulosMasUsados();


    }
}
