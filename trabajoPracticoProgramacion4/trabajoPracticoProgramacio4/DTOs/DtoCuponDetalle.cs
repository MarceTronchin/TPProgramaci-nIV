namespace trabajoPracticoProgramacion4.DTOs
{
	public class DtoCuponDetalle
	{
		public string NroCupon { get; set; }     // Clave primaria y for�nea (a Cupones)
		public int Id_Articulo { get; set; }     // Clave primaria y for�nea (a Articulos)
		public int Cantidad { get; set; }
	}
}