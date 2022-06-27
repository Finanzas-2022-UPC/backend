using AutoMapper;
using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.Cruds.Domain.Repositories;
using FinanzasGrupo2API.Cruds.Domain.Services;
using FinanzasGrupo2API.Cruds.Domain.Services.Communication;
using FinanzasGrupo2API.Cruds.Resources;
using FinanzasGrupo2API.Projects.Domain.Repositories;
using FinanzasGrupo2API.Security.Exceptions;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.Cruds.Services
{
    public class CrudService : ICrudService
    {
        private readonly ICrudRepository _crudRepository;
        private readonly IProyectoRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrudService(ICrudRepository crudRepository, IProyectoRepository projectRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _crudRepository = crudRepository;
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Crud>> ListAsync(string? type, int? projectId)
        {
            var cruds = await _crudRepository.ListAsync();

            if (!(type == null || type.Equals("")) && !projectId.HasValue)
                return cruds.Where(m => m.tipo == type).ToArray();
            else if ((type == null || type.Equals("")) && projectId.HasValue)
                return cruds.Where(m => m.project.id == projectId.Value).ToArray();
            else if (!(type == null || type.Equals("")) && projectId.HasValue)
                return cruds.Where(m => m.project.id == projectId.Value && m.tipo == type).ToArray();

            return cruds.ToArray();
        }

        public async Task<Crud> GetById(int id)
        {
            return await _crudRepository.FindByIdAsync(id);
        }

        public async Task<CrudResponse> SaveAsync(SaveCrudResource crudResource)
        {
            var crud = _mapper.Map<SaveCrudResource, Crud>(crudResource);

            var existingProject = await _projectRepository.FindByIdAsync(crudResource.project_id);
            if (existingProject == null)
                return new CrudResponse("Project Not Found");
            crud.project = existingProject;

            try
            {

                await _crudRepository.AddAsync(crud);
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