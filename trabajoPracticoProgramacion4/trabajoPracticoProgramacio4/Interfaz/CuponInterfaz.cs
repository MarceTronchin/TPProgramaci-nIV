using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;

namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface CuponInterfaz
    {
        Task<List<CuponModel>> GetAllCupones();

        Task<CuponModel> GetCuponPorId(int id);
        Task PostCupon(DtoCupon cuponDto);

        Task PutCupon(int id, DtoCupon cuponDto);

        Task DeleteCupon(int id);
    }
}

