using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Movimientos.Resources
{
    public class SaveTipoMovimientoResource
    {
        [Required] [MaxLength(50)] public string tipo { get; set; }
    }
}

