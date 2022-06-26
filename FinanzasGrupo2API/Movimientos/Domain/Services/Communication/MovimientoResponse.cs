using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Shared.Domain.Services.Communication;

namespace FinanzasGrupo2API.Movimientos.Domain.Services.Communication
{
    public class MovimientoResponse : BaseResponse<Movimiento>
    {
        public MovimientoResponse(string message) : base(message)
        {
        }

        public MovimientoResponse(Movimiento movimiento) : base(movimiento)
        {
        }
    }
}