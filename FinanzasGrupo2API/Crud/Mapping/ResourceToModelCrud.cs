using AutoMapper;
using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.Cruds.Resources;

namespace FinanzasGrupo2API.Cruds.Mapping
{
    public class ResourceToModelCrud : Profile
    {
        public ResourceToModelCrud()
        {
            CreateMap<SaveCrudResource, Crud>();
        }
    }
}