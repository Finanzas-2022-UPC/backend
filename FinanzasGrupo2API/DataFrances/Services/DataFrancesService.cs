using AutoMapper;
using FinanzasGrupo2API.DataFrancess.Domain.Models;
using FinanzasGrupo2API.DataFrancess.Domain.Repositories;
using FinanzasGrupo2API.DataFrancess.Domain.Services;
using FinanzasGrupo2API.DataFrancess.Domain.Services.Communication;
using FinanzasGrupo2API.DataFrancess.Resources;
using FinanzasGrupo2API.Security.Exceptions;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.DataFrancess.Services
{
    public class DataFrancesService : IDataFrancesService
    {
        private readonly IDataFrancesRepository _dataFrancesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DataFrancesService(IDataFrancesRepository dataFrancesRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _dataFrancesRepository = dataFrancesRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DataFrances>> ListAsync()
        {
            return await _dataFrancesRepository.ListAsync();
        }

        public async Task<DataFrances> GetById(int id)
        {
            return await _dataFrancesRepository.FindByIdAsync(id);
        }

        public async Task<DataFrancesResponse> SaveAsync(SaveDataFrancesResource dataFrancesResource)
        {
            var dataFrances = _mapper.Map<SaveDataFrancesResource, DataFrances>(dataFrancesResource);

            try
            {

                await _dataFrancesRepository.AddAsync(dataFrances);
                await _unitOfWork.CompleteAsync();

                _dataFrancesRepository.Update(dataFrances);
                await _unitOfWork.CompleteAsync();

                return new DataFrancesResponse(dataFrances);
            }
            catch (Exception e)
            {
                return new DataFrancesResponse($"An error occured while saving the dataFrances: {e.Message}");
            }
        }

        public async Task<DataFrancesResponse> UpdateAsync(int id, DataFrances dataFrances)
        {
            var existingDataFrances = await _dataFrancesRepository.FindByIdAsync(id);
            if (existingDataFrances == null)
                return new DataFrancesResponse("DataFrances Not Found");
            existingDataFrances = dataFrances;

            try
            {
                _dataFrancesRepository.Update(existingDataFrances);
                await _unitOfWork.CompleteAsync();

                return new DataFrancesResponse(existingDataFrances);
            }
            catch (Exception e)
            {
                return new DataFrancesResponse($"An error occurred while updating the dataFrances: {e.Message}");
            }
        }

        public async Task<DataFrancesResponse> DeleteAsync(int id)
        {
            var existingDataFrances = await _dataFrancesRepository.FindByIdAsync(id);

            if (existingDataFrances == null)
                return new DataFrancesResponse("DataFrances not found");
            try
            {
                _dataFrancesRepository.Remove(existingDataFrances);
                await _unitOfWork.CompleteAsync();

                return new DataFrancesResponse(existingDataFrances);
            }
            catch (Exception e)
            {
                return new DataFrancesResponse($"An error occurred while deleting dataFrances:{e.Message}");
            }
        }
    }
}