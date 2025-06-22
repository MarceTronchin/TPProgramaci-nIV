using System.ComponentModel.DataAnnotations;

public class ArticuloDTO
{
    [Required (ErrorMessage = "Inserte nombre de artículo, el campo es obligatorio.")]
    public String Nombre { get; set; }
   
    [Required (ErrorMessage = "Inserte descripción, el campo es obligatorio.")]
    public String Descripcion { get; set; }

    [Required (ErrorMessage = "Inserte precio, el campo es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valos positivo.")]
    public decimal Precio { get; set; } 

    [Required (RangeErrorMessage = "Inserte cantidad, el campo es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser un valor positivo.")]
    public int Cantidad { get; set; }

}


