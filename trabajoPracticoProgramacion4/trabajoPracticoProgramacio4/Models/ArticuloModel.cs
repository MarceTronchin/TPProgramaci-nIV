using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabajoPracticoProgramacion4.Models
{
    [Table ("Articulos")]
    public class ArticuloModel
    {
        [Key]
        public int IdArticulo { get; set; }

        [Required(ErrorMessage = "Inserte nombre de artículo, el campo es obligatorio.")]   
        public string NombreArticulo { get; set; }

        [Required(ErrorMessage = "Inserte descripción, el campo es obligatorio.")]
        public string DescripcionArticulo { get; set; }

        public bool Activo { get; set; }

        [Required(ErrorMessage = "Inserte precio, el campo es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public decimal Precio { get; set; }
       



    }
}