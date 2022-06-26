using FinanzasGrupo2API.Projects.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.DataFrancess.Domain.Models
{
    public class DataFrances
    {
        public int Id { get; set; }

        public float ValorTerreno { get; set; }
        public float CuotaInicialP { get; set; }
        public float CuotaInicial { get; set; }
        public float TEA { get; set; }
        public string Metodo { get; set; }
        public int PlazoAnhos { get; set; }
        public int PlazoSemestre { get; set; }
        public int PlazoGracia { get; set; }
        public float Capital { get; set; }
        public float TeSemestral { get; set; }
        public float CreditoCapitalizado { get; set; }
        public float NuevaCuota { get; set; }

        //Relationships

        [JsonIgnore]
        public Project Project { get; set; }
             
         }
}