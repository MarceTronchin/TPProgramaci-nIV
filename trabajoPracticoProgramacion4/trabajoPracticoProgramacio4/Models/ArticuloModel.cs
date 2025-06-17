using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabajoPracticoProgramacion4.Models
{
    [Table ("Articulos")]
    public class ArticuloModel
    {
        [Key]
        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public bool Estado { get; set; }
        public decimal Precio { get; set; }
       



    }
}