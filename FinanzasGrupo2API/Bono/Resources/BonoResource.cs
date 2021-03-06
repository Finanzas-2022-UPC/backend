using FinanzasGrupo2API.Projects.Domain.Models;

namespace FinanzasGrupo2API.Bonos.Resources
{
    public class BonoResource
    {
        public int id { get; set; }

        public float valor_nominal { get; set; }
        public float valor_comercial { get; set; }
        public float tasa_cupon { get; set; }
        public string frecuencia_pago { get; set; }
        public string metodo_pago { get; set; }
        public int periodos { get; set; }
        public float tea { get; set; }
        public float prima { get; set; }
        public float estructuracion { get; set; }
        public float colocacion { get; set; }
        public float flotacion { get; set; }
        public float cavali { get; set; }
        public float gastos_adicionales { get; set; }
        public float inflacion { get; set; }
        public float impuesto_renta { get; set; }
        public string moneda { get; set; }

        //Relationships

        public int proyectos_id { get; set; }
    }
}