using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Bonos.Resources
{
    public class SaveBonoResource
    {
        [Required] public float ValorNominal { get; set; }
        [Required] public float ValorComercial { get; set; }
        [Required] public float TasaCupon { get; set; }
        [Required] [MaxLength(50)] public string FrecuenciaPago { get; set; }
        [Required] [MaxLength(50)]  public string MetodoPago { get; set; }
        [Required] public int Periodos { get; set; }
        [Required] public float TEA { get; set; }
        [Required] public float Prima { get; set; }
        [Required] public float Estructuracion { get; set; }
        [Required] public float Colocacion { get; set; }
        [Required] public float Flotacion { get; set; }
        [Required] public float GastosAdicionales { get; set; }
        [Required] public float ImpuestoRenta { get; set; }
        [Required][MaxLength(50)] public string Moneda { get; set; }

        //Relationships
        [Required] public int ProjectId { get; set; }

    }
}

