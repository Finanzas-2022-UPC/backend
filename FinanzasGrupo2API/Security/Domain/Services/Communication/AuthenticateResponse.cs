namespace FinanzasGrupo2API.Security.Domain.Services.Communication
{
    public class AuthenticateResponse
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string token { get; set; }
    }
}