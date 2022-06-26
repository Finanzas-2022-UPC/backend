using AutoMapper;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Resources;

namespace FinanzasGrupo2API.Projects.Mapping
{
    public class ResourceToModelProject : Profile
    {
        public ResourceToModelProject()
        {
            CreateMap<SaveProjectResource, Project>();
        }
    }
}