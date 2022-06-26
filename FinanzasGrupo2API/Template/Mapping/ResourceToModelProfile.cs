using AutoMapper;
using FinanzasGrupo2API.Publications.Domain.Models;
using FinanzasGrupo2API.Publications.Resources;

namespace FinanzasGrupo2API.Publications.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePublicationResource, Publication>();
        }
    }
}