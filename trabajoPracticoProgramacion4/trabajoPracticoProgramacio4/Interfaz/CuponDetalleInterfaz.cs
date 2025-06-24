using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace trabajoPracticoProgramacion4.Interfaz
{
	public interface CuponDetalleInterfaz
	{
		Task<List<CuponDetalle>> GetAllDetallesAsync();
		Task<CuponDetalle?> GetDetalleAsync(int id_Cupon, int idArticulo);
		Task AddDetalleAsync(DtoCuponDetalle dto);
		Task UpdateDetalleAsync(DtoCuponDetalle dto);
		Task DeleteDetalleAsync(int id_Cupon, int idArticulo);
		Task<List<CuponModel>> GetCuponesActivosYVigentes();
	}
}

