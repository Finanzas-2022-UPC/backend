using FinanzasGrupo2API.Projects.Domain.Models;

namespace FinanzasGrupo2API.Cruds.Resources
{
    public class CrudResource
    {
        public int id { get; set; }

        public string tipo { get; set; }
        public string nombre { get; set; }

        //Relationships

        public Proyecto project { get; set; }
    }
}