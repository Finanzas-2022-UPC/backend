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

        public async Task<IEnumerable<DataFrances>> ListAsync(int ?proyectos_id)
        {
            var dataFrances = await _dataFrancesRepository.ListAsync();

            if (proyectos_id.HasValue)
                return dataFrances.Where(dF => dF.proyectos_id == proyectos_id).ToArray();

            return dataFrances.ToArray();
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
            dataFrances.proyecto = existingProject;

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

            existingDataFrances.valor_terreno = dataFrances.valor_terreno;
            existingDataFrances.cuota_inicial_p = dataFrances.cuota_inicial_p;
            existingDataFrances.cuota_inicial = dataFrances.cuota_inicial;
            existingDataFrances.tea = dataFrances.tea;
            existingDataFrances.frecuencia_pago = dataFrances.frecuencia_pago;
            existingDataFrances.metodo = dataFrances.metodo;
            existingDataFrances.plazo_anhos = dataFrances.plazo_anhos;
            existingDataFrances.plazo_semestre = dataFrances.plazo_semestre;
            existingDataFrances.plazo_gracia = dataFrances.plazo_gracia;
            existingDataFrances.capital = dataFrances.capital;
            existingDataFrances.te_semestral = dataFrances.te_semestral;
            existingDataFrances.credito_capitalizado = dataFrances.credito_capitalizado;
            existingDataFrances.nuevo_tiempo = dataFrances.nuevo_tiempo;
            existingDataFrances.nueva_cuota = dataFrances.nueva_cuota;

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