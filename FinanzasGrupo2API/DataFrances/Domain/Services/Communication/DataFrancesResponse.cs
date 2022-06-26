﻿using FinanzasGrupo2API.DataFrancess.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.DataFrancess.Domain.Services.Communication
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