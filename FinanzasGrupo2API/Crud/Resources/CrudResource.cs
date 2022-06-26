namespace FinanzasGrupo2API.Cruds.Resources
{
    public class CrudResource
    {
        public int Id { get; set; }

        public string Tipo { get; set; }
        public string Nombre { get; set; }

        //Relationships

        public int ProjectId { get; set; }
    }
}