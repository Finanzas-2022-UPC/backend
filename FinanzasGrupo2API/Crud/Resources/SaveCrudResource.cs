using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Cruds.Resources
{
    public class SaveCrudResource
    {
        [Required] public string Tipo { get; set; }
        [Required] public string Nombre { get; set; }

        //Relationships
        [Required] public int ProjectId { get; set; }

    }
}

