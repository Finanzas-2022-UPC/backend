using FinanzasGrupo2API.DatasFrances.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.DatasFrances.Domain.Services.Communication
{
    public class DataFrancesResponse : BaseResponse<Models.DataFrances>
    {
        public DataFrancesResponse(string message) : base(message)
        {
        }

        public DataFrancesResponse(Models.DataFrances dataFrances) : base(dataFrances)
        {
        }
    }
}