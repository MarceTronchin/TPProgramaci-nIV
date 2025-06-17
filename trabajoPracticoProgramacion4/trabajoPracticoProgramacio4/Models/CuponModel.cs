using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacio4.Models
{
    [Table("Cupones")]
    public class CuponModel
    {
        [Key]
        public string NroCupon { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PorcentajeDTO { get; set; }
        public decimal ImportePromo { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin {  get; set; }
        public int Id_Tipo_Cupon { get; set; }
        public bool Activo { get; set; }

        #region Navegacion 
        [ForeignKey("Id_Tipo_Cupon")]
        public virtual TipoCuponModel? TipoCupon { get; set; }
        #endregion 

    }
}