using AutoMapper;
using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.Bonos.Domain.Repositories;
using FinanzasGrupo2API.Bonos.Domain.Services;
using FinanzasGrupo2API.Bonos.Domain.Services.Communication;
using FinanzasGrupo2API.Bonos.Resources;
using FinanzasGrupo2API.Security.Exceptions;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.Bonos.Services
{
    public class BonoService : IBonoService
    {
        private readonly IBonoRepository _bonoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BonoService(IBonoRepository bonoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bonoRepository = bonoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Bono>> ListAsync()
        {
            return await _bonoRepository.ListAsync();
        }

        public async Task<Bono> GetById(int id)
        {
            return await _bonoRepository.FindByIdAsync(id);
        }

        public async Task<BonoResponse> SaveAsync(SaveBonoResource bonoResource)
        {
            var bono = _mapper.Map<SaveBonoResource, Bono>(bonoResource);

            try
            {

                await _bonoRepository.AddAsync(bono);
                await _unitOfWork.CompleteAsync();

                _bonoRepository.Update(bono);
                await _unitOfWork.CompleteAsync();

                return new BonoResponse(bono);
            }
            catch (Exception e)
            {
                return new BonoResponse($"An error occured while saving the bono: {e.Message}");
            }
        }

        public async Task<BonoResponse> UpdateAsync(int id, Bono bono)
        {
            var existingBono = await _bonoRepository.FindByIdAsync(id);
            if (existingBono == null)
                return new BonoResponse("Bono Not Found");
            existingBono = bono;

            try
            {
                _bonoRepository.Update(existingBono);
                await _unitOfWork.CompleteAsync();

                return new BonoResponse(existingBono);
            }
            catch (Exception e)
            {
                return new BonoResponse($"An error occurred while updating the bono: {e.Message}");
            }
        }

        public async Task<BonoResponse> DeleteAsync(int id)
        {
            var existingBono = await _bonoRepository.FindByIdAsync(id);

            if (existingBono == null)
                return new BonoResponse("Bono not found");
            try
            {
                _bonoRepository.Remove(existingBono);
                await _unitOfWork.CompleteAsync();

                return new BonoResponse(existingBono);
            }
            catch (Exception e)
            {
                return new BonoResponse($"An error occurred while deleting bono:{e.Message}");
            }
        }
    }
}