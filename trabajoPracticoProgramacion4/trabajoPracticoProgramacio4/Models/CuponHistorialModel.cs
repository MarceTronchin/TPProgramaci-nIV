using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacion4.Models
{
    [Table("Cupones_Historial")]
    public class CuponHistorialModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdHistorial")] // Nueva columna para ser la clave primaria autoincremental
        public int IdHistorial { get; set; }

        public string NroCupon { get; set; }

        [Column("Id_Cupon")] // Añadimos Id_Cupon para la FK a Cupones
        public int Id_Cupon { get; set; } 
        public int  Id_Usuario { get; set; }

        public DateOnly FechaUso { get; set; }

        #region Navegacion
        [ForeignKey("Id_Usuario")]
        public UserModel Usuario { get; set; } 

        [ForeignKey("Id_Cupon")]
        public CuponModel Cupon { get; set; }

        #endregion

    }
}
