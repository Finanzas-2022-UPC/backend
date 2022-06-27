using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Movimientos.Resources
{
    public class SaveMovimientoResource
    {
        [Required] [MaxLength(50)] public string nombre { get; set; }
        [Required] [MaxLength(50)] public string monto { get; set; }
        public float incremento { get; set; }
        [Required][MaxLength(50)] public string mes_aplicable { get; set; }

        //Relationships
        [Required] public int crud_id { get; set; }
        [Required] public int tipo_movimientos_id { get; set; }

    }
}

