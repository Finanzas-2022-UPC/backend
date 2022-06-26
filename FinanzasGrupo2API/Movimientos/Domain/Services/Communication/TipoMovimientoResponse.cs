using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.Movimientos.Domain.Services.Communication
{
    public class TipoMovimientoResponse : BaseResponse<TipoMovimiento>
    {
        public TipoMovimientoResponse(string message) : base(message)
        {
        }

        public TipoMovimientoResponse(TipoMovimiento movimiento) : base(movimiento)
        {
        }
    }
}