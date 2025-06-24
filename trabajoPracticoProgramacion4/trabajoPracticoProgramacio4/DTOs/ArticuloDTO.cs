using System.ComponentModel.DataAnnotations;

namespace trabajoPracticoProgramacion4.DTOs
{
    public class ArticuloDTO
    {
        [Required(ErrorMessage = "Inserte nombre de art�culo, el campo es obligatorio.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Inserte descripci�n, el campo es obligatorio.")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Inserte precio, el campo es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public decimal Precio { get; set; }
    }
}
