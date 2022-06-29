using AutoMapper;
using FinanzasGrupo2API.DatasFrances.Domain.Models;
using FinanzasGrupo2API.DatasFrances.Resources;

namespace FinanzasGrupo2API.DatasFrances.Mapping
{
    public class ModelToResourceDataFrances : Profile
    {
        public ModelToResourceDataFrances()
        {
            CreateMap<DataFrances, DataFrancesResource>();
        }
        
    }
}