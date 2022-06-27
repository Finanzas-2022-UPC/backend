using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.DatasFrances.Domain.Models;

namespace FinanzasGrupo2API.Projects.Resources
{
    public class ProyectoResource
    {
        public int id { get; set; }
             
        public string nombre { get; set; }
             
        public string url_to_image { get; set; }
             
             
        //Relationships
        public int usuarios_id { get; set; }
        public Crud bono { get; set; }
        public DataFrances data_frances { get; set; }

    }
}