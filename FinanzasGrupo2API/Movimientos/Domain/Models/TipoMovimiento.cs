using FinanzasGrupo2API.Projects.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Movimientos.Domain.Models
{
    public class TipoMovimiento
    {
        public int Id { get; set; }

        public string Tipo { get; set; }

    }
}