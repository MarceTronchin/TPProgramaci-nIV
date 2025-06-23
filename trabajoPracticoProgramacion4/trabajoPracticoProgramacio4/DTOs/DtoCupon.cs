using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.Models;

public class DtoCupon
{

    public string NroCupon { get; set; }           // e.g. "123-456-789"
    public int Id_Tipo_Cupon { get; set; }

    [Required]
    public string Nombre { get; set; }    //
    [Required]
    public string Descripcion { get; set; }

    [Range(0.01, 100, ErrorMessage = "El porcentaje debe estar entre 0.01 y 100.")]
    public decimal? PorcentajeDto { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El importe debe ser mayor a 0.")]
    public decimal? ImportePromo { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime FechaInicio { get; set; }

    //[Required, DataType(DataType.Date)]
    //[DateGreaterThan("FechaInicio", ErrorMessage = "La fecha fin debe ser posterior a la fecha inicio.")]
    public DateTime FechaFin { get; set; }

    public bool Activo { get; set; }


}

