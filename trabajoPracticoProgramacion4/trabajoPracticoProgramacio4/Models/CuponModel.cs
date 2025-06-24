using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacio4.Models
{
    [Table("Cupones")]
    public class CuponModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que la DB genera el valor (autoincremental)
        [Column("Id_Cupon")] // Mapea a la columna Id_Cupon en la base de datos
        public int Id_Cupon { get; set; }

        public string NroCupon { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PorcentajeDTO { get; set; }
        public decimal ImportePromo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public int Id_Tipo_Cupon { get; set; }
        public bool Activo { get; set; }

        #region Navegacion 
        [ForeignKey("Id_Tipo_Cupon")]
        public virtual TipoCuponModel? TipoCupon { get; set; }

        // Se agrega propiedades de navegación para Cupones_Clientes y Cupones_Detalle
        // Un cupón puede ser asignado a muchos clientes y tener muchos artículos en detalle
        public ICollection<CuponClienteModel> CuponesClientes { get; set; } = new List<CuponClienteModel>();
        public ICollection<CuponDetalle> CuponesDetalles { get; set; } = new List<CuponDetalle>();

        #endregion
    }
}