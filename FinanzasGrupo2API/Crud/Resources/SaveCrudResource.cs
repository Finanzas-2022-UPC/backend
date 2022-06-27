using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Cruds.Resources
{
    public class SaveCrudResource
    {
        [Required] public string tipo { get; set; }
        [Required] public string nombre { get; set; }

        //Relationships
        [Required] public int project_id { get; set; }

    }
}

