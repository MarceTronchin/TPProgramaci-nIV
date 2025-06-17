using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabajoPracticoProgramacio4.Models
{
    [Table("Cupones_Detalle")]
    public class CuponDetalle
    {

        public string NroCupon { get; set; }
        public int IdArticulo { get; set; }
        public int cantidad { get; set; }


        #region Navegacion
        public Cupon cupon { get; set; }
        public Articulo articulo { get; set; }

        #endregion

    }
