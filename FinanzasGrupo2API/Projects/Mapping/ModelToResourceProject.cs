using AutoMapper;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Resources;

namespace FinanzasGrupo2API.Projects.Mapping
{
    public class ModelToResourceProyecto : Profile
    {
        public ModelToResourceProyecto()
        {
            CreateMap<Proyecto, ProyectoResource>();
        }
        
    }
}