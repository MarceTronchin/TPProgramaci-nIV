using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.DTOs;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface IArticulo
    {
        Task<List<ArticuloModel>> GetAllArticulos();

        Task<ArticuloModel> GetArticuloPorID(int id);

        Task PostArticulo(ArticuloDTO articuloDTO);

        Task PutArticulo(int id, ArticuloDTO articuloDTO);

        Task DeleteArticulo(int id);
    }
}
