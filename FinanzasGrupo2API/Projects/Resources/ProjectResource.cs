namespace FinanzasGrupo2API.Projects.Resources
{
    public class ProjectResource
    {
        public int Id { get; set; }
             
        public string Name { get; set; }
             
        public string UrlToImage { get; set; }
             
             
        //Relationships
        public int UserId { get; set; }
    }
}