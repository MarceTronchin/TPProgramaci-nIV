using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacio4.Models
{
    [Table("Cupones_Detalle")]
    public class CuponDetalle
    {
        // Las propiedades que forman la clave primaria compuesta.
        // Se mapearán a Id_Cupon y Id_Articulo en la DB.
        [Column("Id_Cupon")] // Mapea a la columna Id_Cupon
        public int Id_Cupon { get; set; } // Cambiado de NroCupon a Id_Cupon para FK

        [Column("id_Articulo")] // Mapea a la columna id_Articulo
        public int IdArticulo { get; set; }

        public int Cantidad { get; set; } 

        #region Navegacion
        
        [ForeignKey("Id_Cupon")]
        public CuponModel Cupon { get; set; } 
        [ForeignKey("IdArticulo")] 
        public ArticuloModel Articulo { get; set; } 
        #endregion

    }

}
