using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.Cruds.Domain.Services.Communication
{
    public class CrudResponse : BaseResponse<Crud>
    {
        public CrudResponse(string message) : base(message)
        {
        }

        public CrudResponse(Crud crud) : base(crud)
        {
        }
    }
}