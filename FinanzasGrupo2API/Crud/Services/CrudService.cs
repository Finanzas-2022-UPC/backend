using AutoMapper;
using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.Cruds.Domain.Repositories;
using FinanzasGrupo2API.Cruds.Domain.Services;
using FinanzasGrupo2API.Cruds.Domain.Services.Communication;
using FinanzasGrupo2API.Cruds.Resources;
using FinanzasGrupo2API.Security.Exceptions;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.Cruds.Services
{
    public class CrudService : ICrudService
    {
        private readonly ICrudRepository _crudRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrudService(ICrudRepository crudRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _crudRepository = crudRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Crud>> ListAsync()
        {
            return await _crudRepository.ListAsync();
        }

        public async Task<Crud> GetById(int id)
        {
            return await _crudRepository.FindByIdAsync(id);
        }

        public async Task<CrudResponse> SaveAsync(SaveCrudResource crudResource)
        {
            var crud = _mapper.Map<SaveCrudResource, Crud>(crudResource);

            try
            {

                await _crudRepository.AddAsync(crud);
                await _unitOfWork.CompleteAsync();

                _crudRepository.Update(crud);
                await _unitOfWork.CompleteAsync();

                return new CrudResponse(crud);
            }
            catch (Exception e)
            {
                return new CrudResponse($"An error occured while saving the crud: {e.Message}");
            }
        }

        public async Task<CrudResponse> UpdateAsync(int id, Crud crud)
        {
            var existingCrud = await _crudRepository.FindByIdAsync(id);
            if (existingCrud == null)
                return new CrudResponse("Crud Not Found");
            existingCrud = crud;

            try
            {
                _crudRepository.Update(existingCrud);
                await _unitOfWork.CompleteAsync();

                return new CrudResponse(existingCrud);
            }
            catch (Exception e)
            {
                return new CrudResponse($"An error occurred while updating the crud: {e.Message}");
            }
        }

        public async Task<CrudResponse> DeleteAsync(int id)
        {
            var existingCrud = await _crudRepository.FindByIdAsync(id);

            if (existingCrud == null)
                return new CrudResponse("Crud not found");
            try
            {
                _crudRepository.Remove(existingCrud);
                await _unitOfWork.CompleteAsync();

                return new CrudResponse(existingCrud);
            }
            catch (Exception e)
            {
                return new CrudResponse($"An error occurred while deleting crud:{e.Message}");
            }
        }
    }
}