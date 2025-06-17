using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trabajoPracticoProgramacion4.Models
{
	[Table("Tipo_Cupon")]
	public class TipoCuponModel
	{
		[Key]
		[Column("Id_TipoCupon")]
		public int Id { get; set; }

		public string Nombre { get; set; }

		// Relación: Un tipo puede tener muchos cupones
		public ICollection<CuponModel> Cupones { get; set; } = new List<CuponModel>();
	}
}
