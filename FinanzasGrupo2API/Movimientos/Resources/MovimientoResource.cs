using FinanzasGrupo2API.Movimientos.Domain.Models;

namespace FinanzasGrupo2API.Movimientos.Resources
{
    public class MovimientoResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Monto { get; set; }
        public float Incremento { get; set; }
        public string MesAplicable { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        //Relationships
             
        public int CrudId { get; set; }
    }
}