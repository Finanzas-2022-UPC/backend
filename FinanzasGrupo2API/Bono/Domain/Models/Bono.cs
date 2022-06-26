using FinanzasGrupo2API.Projects.Domain.Models;
using System.Text.Json.Serialization;

namespace FinanzasGrupo2API.Bonos.Domain.Models
{
    public class Bono
    {
        public int Id { get; set; }

        public float ValorNominal { get; set; }
        public float ValorComercial { get; set; }
        public float TasaCupon { get; set; }
        public string FrecuenciaPago { get; set; }
        public string MetodoPago { get; set; }
        public int Periodos { get; set; }
        public float TEA { get; set; }
        public float Prima { get; set; }
        public float Estructuracion { get; set; }
        public float Colocacion { get; set; }
        public float Flotacion { get; set; }
        public float GastosAdicionales { get; set; }
        public float ImpuestoRenta { get; set; }
        public string Moneda { get; set; }

        //Relationships

        [JsonIgnore]
        public Project Project { get; set; }
             
         }
}