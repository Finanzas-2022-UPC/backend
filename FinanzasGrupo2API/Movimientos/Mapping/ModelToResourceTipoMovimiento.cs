using AutoMapper;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Movimientos.Resources;

namespace FinanzasGrupo2API.Movimientos.Mapping
{
    public class ModelToResourceTipoMovimiento : Profile
    {
        public ModelToResourceTipoMovimiento()
        {
            CreateMap<TipoMovimiento, TìpoMovimientoResource>();
        }
        
    }
}