using System.ComponentModel.DataAnnotations;

namespace FinanzasGrupo2API.DataFrancess.Resources
{
    public class SaveDataFrancesResource
    {
        [Required] public float ValorTerreno { get; set; }
        public float CuotaInicialP { get; set; }
        public float CuotaInicial { get; set; }
        public float TEA { get; set; }
        [Required] [MaxLength(50)] public string Metodo { get; set; }
        public int PlazoAnhos { get; set; }
        public int PlazoSemestre { get; set; }
        [Required] public int PlazoGracia { get; set; }
        public float Capital { get; set; }
        public float TeSemestral { get; set; }
        public int CreditoCapitalizado { get; set; }
        public float NuevaCuota { get; set; }

        //Relationships
        [Required] public int ProjectId { get; set; }

    }
}

