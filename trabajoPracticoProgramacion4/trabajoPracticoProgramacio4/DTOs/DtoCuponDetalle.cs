namespace trabajoPracticoProgramacion4.DTOs
{
	public class DtoCuponDetalle
	{
		public int Id_Cupon { get; set; }     // Clave primaria y for�nea (a Cupones)
		public int IdArticulo { get; set; }     // Clave primaria y for�nea (a Articulos)
		public int Cantidad { get; set; }
	}
}