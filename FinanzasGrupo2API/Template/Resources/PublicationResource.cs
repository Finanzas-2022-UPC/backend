using FinanzasGrupo2API.Business.Resources;

namespace FinanzasGrupo2API.Publications.Resources
{
    public class PublicationResource
    {
        public int Id { get; set; }
        
        public short PublicationType { get; set; }
             
        public string Title { get; set; }
             
        public string Content { get; set; }
             
        /*public int ParticipantLimit { get; set; }*/
             
        /*public int PrizePool { get; set; }
             
        public int TournamentId { get; set; }
             
        public string TournamentDate { get; set; }
             
        public string TournamentHour { get; set; }*/
        
        public string UrlToImage { get; set; }
             
        public string CreatedAt { get; set; }
        
        /*public int TournamentId { get; set; }*/
        
        public TournamentResource Tournament { get; set; }
             
        //Relationships
        public int GameId { get; set; }
             
        public int UserId { get; set; }
    }
}