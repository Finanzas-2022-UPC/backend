using AutoMapper;
using FinanzasGrupo2API.DataFrancess.Domain.Models;
using FinanzasGrupo2API.DataFrancess.Resources;

namespace FinanzasGrupo2API.DataFrancess.Mapping
{
    public class ResourceToModelDataFrances : Profile
    {
        public ResourceToModelDataFrances()
        {
            CreateMap<SaveDataFrancesResource, DataFrances>();
        }
    }
}