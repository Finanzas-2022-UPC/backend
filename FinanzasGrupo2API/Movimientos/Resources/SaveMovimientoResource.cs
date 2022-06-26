using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Movimientos.Resources
{
    public class SaveMovimientoResource
    {
        [Required] public float ValorNominal { get; set; }
        [Required] public float ValorComercial { get; set; }
        [Required] public float TasaCupon { get; set; }
        [Required] [MaxLength(50)] public string Nombre { get; set; }
        [Required] [MaxLength(50)] public string Monto { get; set; }
        public float Incremento { get; set; }
        [Required][MaxLength(50)] public string MesAplicable { get; set; }

        //Relationships
        [Required] public int CrudId { get; set; }
        [Required] public int TipoMovimientoId { get; set; }

    }
}

