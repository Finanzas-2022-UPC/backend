using AutoMapper;
using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.Bonos.Resources;

namespace FinanzasGrupo2API.Bonos.Mapping
{
    public class ModelToResourceBono : Profile
    {
        public ModelToResourceBono()
        {
            CreateMap<Bono, BonoResource>();
        }
        
    }
}