using AutoMapper;
using FinanzasGrupo2API.DatasFrances.Domain.Models;
using FinanzasGrupo2API.DatasFrances.Domain.Repositories;
using FinanzasGrupo2API.DatasFrances.Domain.Services;
using FinanzasGrupo2API.DatasFrances.Domain.Services.Communication;
using FinanzasGrupo2API.DatasFrances.Resources;
using FinanzasGrupo2API.Projects.Domain.Repositories;
using FinanzasGrupo2API.Security.Exceptions;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.DatasFrances.Services
{
    public class DataFrancesService : IDataFrancesService
    {
        private readonly IDataFrancesRepository _dataFrancesRepository;
        private readonly IProyectoRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DataFrancesService(IDataFrancesRepository dataFrancesRepository, IProyectoRepository projectRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _dataFrancesRepository = dataFrancesRepository;
            _projectRepository = projectRepository;
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

            var existingProject = await _projectRepository.FindByIdAsync(dataFrancesResource.project_id);
            if (existingProject == null)
                return new DataFrancesResponse("Project Not Found");
            dataFrances.project = existingProject;

            try
            {

                await _dataFrancesRepository.AddAsync(dataFrances);
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