using trabajoPracticoProgramacion4.Models;
using trabajoPracticoProgramacion4.DTOs;

namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface ICuponHistorialServices
    {
        Task RegistrarUsoCupon (CuponHistorialDto cuponHistorialDto);
        Task<List<CuponHistorialModel>> ObtenerHistorialPorUsuario(int idUsuario);


    }
}
