using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacion4.Models
{
    [Table("Cupones_Historial")]
    public class CuponHistorialModel
    {
        
        public string NroCupon { get; set; }

        public int Id_Usuario { get; set; }

        public DateTime FechaUso { get; set; }

        #region Navegacion
        public UserModel usuario { get; set; }
        #endregion

    }
}
