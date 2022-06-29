using AutoMapper;
using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Security.Domain.Services.Communication;
using FinanzasGrupo2API.Security.Resources;

namespace FinanzasGrupo2API.Security.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUsuarioResource, Usuario>();
            CreateMap<RegisterRequest, Usuario>();
            CreateMap<UpdateRequest, Usuario>()
                .ForAllMembers(options=>options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if(property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));
           
        }
    }
}