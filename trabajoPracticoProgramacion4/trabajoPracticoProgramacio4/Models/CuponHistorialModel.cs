using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabajoPracticoProgramacion4.Models
{
    [Table("Cupones_Historial")]
    public class CuponHistorialModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioModel Usuario { get; set; }

        [Required]
        public int CuponId { get; set; }

        [ForeignKey("CuponId")]
        public CuponModel Cupon { get; set; }

        public DateTime FechaUso { get; set; } = DateTime.Now;
    }
}
