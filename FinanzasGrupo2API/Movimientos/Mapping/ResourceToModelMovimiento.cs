using AutoMapper;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Movimientos.Resources;

namespace FinanzasGrupo2API.Movimientos.Mapping
{
    public class ResourceToModelMovimiento : Profile
    {
        public ResourceToModelMovimiento()
        {
            CreateMap<SaveMovimientoResource, Movimiento>();
        }
    }
}