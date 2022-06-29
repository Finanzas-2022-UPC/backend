namespace FinanzasGrupo2API.DatasFrances.Resources
{
    public class DataFrancesResource
    {
        public int id { get; set; }

        public float valor_terreno { get; set; }
        public float cuota_inicial_p { get; set; }
        public float cuota_inicial { get; set; }
        public float tea { get; set; }
        public string frecuencia_pago { get; set; }
        public string metodo { get; set; }
        public int plazo_anhos { get; set; }
        public int plazo_semestre { get; set; }
        public int plazo_gracia { get; set; }
        public float capital { get; set; }
        public float te_semestral { get; set; }
        public float credito_capitalizado { get; set; }
        public int nuevo_tiempo { get; set; }
        public float nueva_cuota { get; set; }

        //Relationships

        public int proyectos_id { get; set; }
    }
}