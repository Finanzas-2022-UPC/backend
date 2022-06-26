using FinanzasGrupo2API.Business.Domain.Models;

namespace FinanzasGrupo2API.Publications.Domain.Models
{
    public class Publication
    {
        public int Id { get; set; }
        
        public short PublicationType { get; set; }
             
        public string Title { get; set; }
             
        public string Content { get; set; }
             

        
        public string UrlToImage { get; set; }
        
        public string CreatedAt { get; set; }
             
             
        //Relationships

        public int UserId { get; set; }
             
         }
}