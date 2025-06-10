using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacio4.Models
{
    [Table("Usuarios")]
    public class UserModel
    {
        [Key]
        public int Id_Usuario { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public int Id_Rol { get; set; }


        #region Navegacion 

        [ForeignKey("Id_Rol")]

        public virtual RolModel? Rol { get; set; }

        #endregion 

    }
}
