using AutoMapper;
using FinanzasGrupo2API.Security.Domain.Models;
using FinanzasGrupo2API.Security.Domain.Services.Communication;
using FinanzasGrupo2API.Security.Resources;

namespace FinanzasGrupo2API.Security.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Usuario, AuthenticateResponse>();
            
            CreateMap<Usuario, UsuarioResource>();

        }
    }
}