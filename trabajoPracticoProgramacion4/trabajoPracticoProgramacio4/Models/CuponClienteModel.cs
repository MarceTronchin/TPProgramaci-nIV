using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using trabajoPracticoProgramacio4.Models;

namespace trabajoPracticoProgramacion4.Models
{
    [Table("Cupones_Clientes")]
    public class CuponClienteModel
    {
        // La clave compuesta ahora ser� Id_Cupon y Id_Usuario.
        // No necesitamos [Key] aqu� porque la clave compuesta se definir� en AppDbContext.
        [Column("Id_Cupon")] // Mapea a la columna Id_Cupon de la tabla Cupones_Clientes
        public int Id_Cupon { get; set; }
        public string NroCupon { get; set; }

        public int Id_Usuario { get; set; }

        public DateTime FechaAsignado { get; set; }

        #region Navegacion
        // Propiedades de navegaci�n a los modelos relacionados
        [ForeignKey("Id_Cupon")]
        public CuponModel Cupon { get; set; } // Navegaci�n al cup�n relacionado

        [ForeignKey("Id_Usuario")]
        public UserModel Usuario { get; set; } // Navegaci�n al usuario relacionado
        #endregion

    }
}
