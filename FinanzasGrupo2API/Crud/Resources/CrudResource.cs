using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Models;

namespace FinanzasGrupo2API.Cruds.Resources
{
    public class CrudResource
    {
        public int id { get; set; }

        public string tipo { get; set; }
        public string nombre { get; set; }

        //Relationships
        public int proyectos_id { get; set; }

        public IList<Movimiento> movimientos { get; set; }
    }
}