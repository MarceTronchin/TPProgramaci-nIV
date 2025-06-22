using System.ComponentModel.DataAnnotations;

public class ArticuloDTO
{
    [Required (ErrorMessage = "Inserte nombre de art�culo, el campo es obligatorio.")]
    public String Nombre { get; set; }
   
    [Required (ErrorMessage = "Inserte descripci�n, el campo es obligatorio.")]
    public String Descripcion { get; set; }

    [Required (ErrorMessage = "Inserte precio, el campo es obligatorio.")]
    public decimal Precio { get; set; } 

    [Required (ErrorMessage = "Inserte cantidad, el campo es obligatorio.")]
    public int Cantidad { get; set; }


}


