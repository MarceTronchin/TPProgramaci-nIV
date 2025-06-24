using trabajoPracticoProgramacio4.Models;

namespace trabajoPracticoProgramacion4.Interfaz
{
    public interface ICuponCliente
    {
        Task<List<CuponModel>> VerCuponesDisponiblesTodos(int idUsuario);
        Task ReclamarCupon(int idUsuario, string NroCupon);
        Task<List<CuponModel>> VerCuponesReclamados(int idUsuario);

        

    }
}
