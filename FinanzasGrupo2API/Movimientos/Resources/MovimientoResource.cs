using FinanzasGrupo2API.Movimientos.Domain.Models;

namespace FinanzasGrupo2API.Movimientos.Resources
{
    public class MovimientoResource
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public string monto { get; set; }
        public float incremento { get; set; }
        public string mes_aplicable { get; set; }
        public int tipo_movimientos_id { get; set; }

        //Relationships
             
        public int crud_id { get; set; }
    }
}