using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface CuponDetalleInterfaz
    {
        Task<List<CuponDetalle>> GetDetallePorId(int Id_Cupon); // todos los detalles de un cupón

        Task UpdateDetalleAsync(DtoCuponDetalle dto);

        Task DeleteDetalleAsync(int Id_Cupon, int IdArticulo);
    }
}


