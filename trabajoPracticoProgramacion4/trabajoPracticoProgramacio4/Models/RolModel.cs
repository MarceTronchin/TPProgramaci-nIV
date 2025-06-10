using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabajoPracticoProgramacion4.Models
{
    [Table("Roles")]
    public class RolModel
    {
        [Key] 
        public int Id_Rol { get; set; }
        public string Nombre { get; set; }
    }
}
