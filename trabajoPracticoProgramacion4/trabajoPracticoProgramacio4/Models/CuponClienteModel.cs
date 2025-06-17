using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabajoPracticoProgramacion4.Models
{
    [Table("Cupones_Clientes")]
    public class CuponClienteModel
    {
        [Key]
        public string NroCupon { get; set; }

        public int Id_Usuario { get; set; }

        public DateTime FechaAsignado { get; set; }

    }
}
