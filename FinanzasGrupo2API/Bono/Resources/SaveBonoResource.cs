using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Bonos.Resources
{
    public class SaveBonoResource
    {
        [Required] public float valor_nominal { get; set; }
        [Required] public float valor_comercial { get; set; }
        [Required] public float tasa_cupon { get; set; }
        [Required] [MaxLength(50)] public string frecuencia_pago { get; set; }
        [Required] [MaxLength(50)]  public string metodo_pago { get; set; }
        [Required] public int periodos { get; set; }
        [Required] public float tea { get; set; }
        [Required] public float prima { get; set; }
        [Required] public float estructuracion { get; set; }
        [Required] public float colocacion { get; set; }
        [Required] public float flotacion { get; set; }
        [Required] public float gastos_adicionales { get; set; }
        [Required] public float impuesto_renta { get; set; }
        [Required][MaxLength(50)] public string moneda { get; set; }

        //Relationships
        [Required] public int proyectos_id { get; set; }

    }
}

