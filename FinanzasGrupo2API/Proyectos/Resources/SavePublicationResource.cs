using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.Publications.Resources
{
    public class SavePublicationResource
    {

        [Required] public short PublicationType { get; set; }
             
        [Required] [MinLength(15)] public string Title { get; set; }
             
        [Required] [MinLength(40)] public string Content { get; set; }
             
        public int ParticipantLimit { get; set; }
             
        public int PrizePool { get; set; }

        public string TournamentDate { get; set; }
             
        public string TournamentHour { get; set; }
        
        public string UrlToImage { get; set; }
             
        [Required] public string CreatedAt { get; set; }
        
        public int GameId { get; set; }
             
       [Required] public int UserId { get; set; }

    }
}

