namespace FinanzasGrupo2API.Bonos.Resources
{
    public class BonoResource
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
             
        public int ProjectId { get; set; }
    }
}