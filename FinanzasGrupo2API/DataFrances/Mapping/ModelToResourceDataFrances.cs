using AutoMapper;
using FinanzasGrupo2API.DataFrancess.Domain.Models;
using FinanzasGrupo2API.DataFrancess.Resources;

namespace FinanzasGrupo2API.DataFrancess.Mapping
{
    public class ModelToResourceDataFrances : Profile
    {
        public ModelToResourceDataFrances()
        {
            CreateMap<DataFrances, DataFrancesResource>();
        }
        
    }
}