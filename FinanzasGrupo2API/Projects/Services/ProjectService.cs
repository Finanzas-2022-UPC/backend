using AutoMapper;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Repositories;
using FinanzasGrupo2API.Projects.Domain.Services;
using FinanzasGrupo2API.Projects.Domain.Services.Communication;
using FinanzasGrupo2API.Projects.Resources;
using FinanzasGrupo2API.Security.Domain.Repositories;
using IUnitOfWork = FinanzasGrupo2API.Shared.Domain.Repositories.IUnitOfWork;

namespace FinanzasGrupo2API.Projects.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Project>> ListAsync(int ?userId)
        {
            var projects = await _projectRepository.ListAsync();

            if (userId.HasValue)
                return projects.Where(p => p.User.Id == userId).ToArray();
            return projects.ToArray();
        }
       
        public async Task<Project> GetById(int id)
        {
            return await _projectRepository.FindByIdAsync(id);
        }

        public async Task<ProjectResponse> SaveAsync(SaveProjectResource projectResource)
        {
            var project = _mapper.Map<SaveProjectResource, Project>(projectResource);

            var existingUser = await _userRepository.FindByIdAsync(projectResource.UserId);
            if (existingUser == null)
                return new ProjectResponse("User Not Found");
            project.User = existingUser;

            try
            {

                await _projectRepository.AddAsync(project);
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