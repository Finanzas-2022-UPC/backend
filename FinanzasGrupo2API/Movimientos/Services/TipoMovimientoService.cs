using AutoMapper;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Movimientos.Domain.Repositories;
using FinanzasGrupo2API.Movimientos.Domain.Services;
using FinanzasGrupo2API.Movimientos.Domain.Services.Communication;
using FinanzasGrupo2API.Movimientos.Resources;
using FinanzasGrupo2API.Security.Exceptions;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.Movimientos.Services
{
    public class TipoMovimientoService : ITipoMovimientoService
    {
        private readonly ITipoMovimientoRepository _tipoMovimientoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoMovimientoService(ITipoMovimientoRepository tipoMovimientoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tipoMovimientoRepository = tipoMovimientoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoMovimiento>> ListAsync()
        {
            return await _tipoMovimientoRepository.ListAsync();
        }

        public async Task<TipoMovimiento> GetById(int id)
        {
            return await _tipoMovimientoRepository.FindByIdAsync(id);
        }

        public async Task<TipoMovimientoResponse> SaveAsync(SaveTipoMovimientoResource movimientoResource)
        {
            var movimiento = _mapper.Map<SaveTipoMovimientoResource, TipoMovimiento>(movimientoResource);

            try
            {

                await _tipoMovimientoRepository.AddAsync(movimiento);
                await _unitOfWork.CompleteAsync();

                return new TipoMovimientoResponse(movimiento);
            }
            catch (Exception e)
            {
                return new TipoMovimientoResponse($"An error occured while saving the movimiento: {e.Message}");
            }
        }

        public async Task<TipoMovimientoResponse> UpdateAsync(int id, TipoMovimiento movimiento)
        {
            var existingTipoMovimiento = await _tipoMovimientoRepository.FindByIdAsync(id);
            if (existingTipoMovimiento == null)
                return new TipoMovimientoResponse("TipoMovimiento Not Found");
            existingTipoMovimiento = movimiento;

            try
            {
                _tipoMovimientoRepository.Update(existingTipoMovimiento);
                await _unitOfWork.CompleteAsync();

                return new TipoMovimientoResponse(existingTipoMovimiento);
            }
            catch (Exception e)
            {
                return new TipoMovimientoResponse($"An error occurred while updating the movimiento: {e.Message}");
            }
        }

        public async Task<TipoMovimientoResponse> DeleteAsync(int id)
        {
            var existingTipoMovimiento = await _tipoMovimientoRepository.FindByIdAsync(id);

            if (existingTipoMovimiento == null)
                return new TipoMovimientoResponse("TipoMovimiento not found");
            try
            {
                _tipoMovimientoRepository.Remove(existingTipoMovimiento);
                await _unitOfWork.CompleteAsync();

                return new TipoMovimientoResponse(existingTipoMovimiento);
            }
            catch (Exception e)
            {
                return new TipoMovimientoResponse($"An error occurred while deleting movimiento:{e.Message}");
            }
        }
    }
}