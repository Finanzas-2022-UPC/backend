using AutoMapper;
using FinanzasGrupo2API.Cruds.Domain.Repositories;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Movimientos.Domain.Repositories;
using FinanzasGrupo2API.Movimientos.Domain.Services;
using FinanzasGrupo2API.Movimientos.Domain.Services.Communication;
using FinanzasGrupo2API.Movimientos.Resources;
using FinanzasGrupo2API.Security.Exceptions;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.Movimientos.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ITipoMovimientoRepository _tipoMovimientoRepository;
        private readonly ICrudRepository _crudRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovimientoService(IMovimientoRepository movimientoRepository, ITipoMovimientoRepository tipoMovimientoRepository, ICrudRepository crudRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _movimientoRepository = movimientoRepository;
            _tipoMovimientoRepository = tipoMovimientoRepository;
            _crudRepository = crudRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Movimiento>> ListAsync(int ?crudId, int ?tipoMovimiento)
        {
            var movimientos = await _movimientoRepository.ListAsync();

            if (crudId.HasValue && !tipoMovimiento.HasValue)
                return movimientos.Where(m => m.crud.id == crudId).ToArray();
            else if (!crudId.HasValue && tipoMovimiento.HasValue)
                return movimientos.Where(m => m.tipo_movimiento.id == tipoMovimiento).ToArray();
            else if (crudId.HasValue && tipoMovimiento.HasValue)
                return movimientos.Where(m => m.tipo_movimiento.id == tipoMovimiento && m.crud.id == crudId).ToArray();

            return movimientos.ToArray();
        }

        public async Task<Movimiento> GetById(int id)
        {
            return await _movimientoRepository.FindByIdAsync(id);
        }

        public async Task<MovimientoResponse> SaveAsync(SaveMovimientoResource movimientoResource)
        {
            var movimiento = _mapper.Map<SaveMovimientoResource, Movimiento>(movimientoResource);

            var existingCrud = await _crudRepository.FindByIdAsync(movimientoResource.crud_id);
            if (existingCrud == null)
                return new MovimientoResponse("Crud Not Found");
            movimiento.crud = existingCrud;

            var existingTipoMovimiento = await _tipoMovimientoRepository.FindByIdAsync(movimientoResource.tipo_movimientos_id);
            if (existingTipoMovimiento == null)
                return new MovimientoResponse("TipoMovimiento Not Found");
            movimiento.tipo_movimiento = existingTipoMovimiento;

            try
            {

                await _movimientoRepository.AddAsync(movimiento);
                await _unitOfWork.CompleteAsync();

                return new MovimientoResponse(movimiento);
            }
            catch (Exception e)
            {
                return new MovimientoResponse($"An error occured while saving the movimiento: {e.Message}");
            }
        }

        public async Task<MovimientoResponse> UpdateAsync(int id, Movimiento movimiento)
        {
            var existingMovimiento = await _movimientoRepository.FindByIdAsync(id);
            if (existingMovimiento == null)
                return new MovimientoResponse("Movimiento Not Found");
            existingMovimiento = movimiento;

            try
            {
                _movimientoRepository.Update(existingMovimiento);
                await _unitOfWork.CompleteAsync();

                return new MovimientoResponse(existingMovimiento);
            }
            catch (Exception e)
            {
                return new MovimientoResponse($"An error occurred while updating the movimiento: {e.Message}");
            }
        }

        public async Task<MovimientoResponse> DeleteAsync(int id)
        {
            var existingMovimiento = await _movimientoRepository.FindByIdAsync(id);

            if (existingMovimiento == null)
                return new MovimientoResponse("Movimiento not found");
            try
            {
                _movimientoRepository.Remove(existingMovimiento);
                await _unitOfWork.CompleteAsync();

                return new MovimientoResponse(existingMovimiento);
            }
            catch (Exception e)
            {
                return new MovimientoResponse($"An error occurred while deleting movimiento:{e.Message}");
            }
        }
    }
}