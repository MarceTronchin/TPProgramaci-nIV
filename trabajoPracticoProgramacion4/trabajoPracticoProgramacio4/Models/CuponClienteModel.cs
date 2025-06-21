using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using trabajoPracticoProgramacio4.Models;

namespace trabajoPracticoProgramacion4.Models
{
    [Table("Cupones_Clientes")]
    public class CuponClienteModel
    {
        // La clave compuesta ahora será Id_Cupon y Id_Usuario.
        // No necesitamos [Key] aquí porque la clave compuesta se definirá en AppDbContext.
        [Column("Id_Cupon")] // Mapea a la columna Id_Cupon de la tabla Cupones_Clientes
        public int Id_Cupon { get; set; }
        public string NroCupon { get; set; }

        public int Id_Usuario { get; set; }

        public DateTime FechaAsignado { get; set; }

        #region Navegacion
        // Propiedades de navegación a los modelos relacionados
        [ForeignKey("Id_Cupon")]
        public CuponModel Cupon { get; set; } // Navegación al cupón relacionado

        [ForeignKey("Id_Usuario")]
        public UserModel Usuario { get; set; } // Navegación al usuario relacionado
        #endregion

    }
}
