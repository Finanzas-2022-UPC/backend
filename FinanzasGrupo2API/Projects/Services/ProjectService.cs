using AutoMapper;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Repositories;
using FinanzasGrupo2API.Projects.Domain.Services;
using FinanzasGrupo2API.Projects.Domain.Services.Communication;
using FinanzasGrupo2API.Projects.Resources;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.Projects.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _projectRepository.ListAsync();
        }
       
        public async Task<Project> GetById(int id)
        {
            return await _projectRepository.FindByIdAsync(id);
        }

        public async Task<ProjectResponse> SaveAsync(SaveProjectResource projectResource)
        {
            var project = _mapper.Map<SaveProjectResource, Project>(projectResource);

            try
            {

                await _projectRepository.AddAsync(project);
                await _unitOfWork.CompleteAsync();

                _projectRepository.Update(project);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(project);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error occured while saving the project: {e.Message}");
            }
        }

        public async Task<ProjectResponse> UpdateAsync(int id, Project project)
        {
            var existingProject = await _projectRepository.FindByIdAsync(id);
            if (existingProject == null)
                return new ProjectResponse("Project Not Found");
            existingProject = project;

            try
            {
                _projectRepository.Update(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error occurred while updating the project: {e.Message}");
            }
        }

        public async Task<ProjectResponse> DeleteAsync(int id)
        {
            var existingProject = await _projectRepository.FindByIdAsync(id);

            if (existingProject == null)
                return new ProjectResponse("Project not found");
            try
            {
                _projectRepository.Remove(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error occurred while deleting project:{e.Message}");
            }
        }
    }
}