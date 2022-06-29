using AutoMapper;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Resources;

namespace FinanzasGrupo2API.Projects.Mapping
{
    public class ResourceToModelProyecto : Profile
    {
        public ResourceToModelProyecto()
        {
            CreateMap<SaveProyectoResource, Proyecto>();
        }
    }
}