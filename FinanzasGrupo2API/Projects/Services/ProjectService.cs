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
    public class ProyectoService : IProyectoService
    {
        private readonly IProyectoRepository _projectRepository;
        private readonly IUsuarioRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProyectoService(IProyectoRepository projectRepository, IUsuarioRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Proyecto>> ListAsync(int ?userId)
        {
            var projects = await _projectRepository.ListAsync();

            if (userId.HasValue)
                return projects.Where(p => p.usuario.id == userId).ToArray();
            return projects.ToArray();
        }
       
        public async Task<Proyecto> GetById(int id)
        {
            return await _projectRepository.FindByIdAsync(id);
        }

        public async Task<ProyectoResponse> SaveAsync(SaveProyectoResource projectResource)
        {
            var project = _mapper.Map<SaveProyectoResource, Proyecto>(projectResource);

            var existingUser = await _userRepository.FindByIdAsync(projectResource.usuarios_id);
            if (existingUser == null)
                return new ProyectoResponse("User Not Found");
            project.usuario = existingUser;

            try
            {

                await _projectRepository.AddAsync(project);
                await _unitOfWork.CompleteAsync();

                return new ProyectoResponse(project);
            }
            catch (Exception e)
            {
                return new ProyectoResponse($"An error occured while saving the project: {e.Message}");
            }
        }

        public async Task<ProyectoResponse> UpdateAsync(int id, Proyecto project)
        {
            var existingProject = await _projectRepository.FindByIdAsync(id);
            if (existingProject == null)
                return new ProyectoResponse("Project Not Found");
            existingProject = project;

            try
            {
                _projectRepository.Update(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProyectoResponse(existingProject);
            }
            catch (Exception e)
            {
                return new ProyectoResponse($"An error occurred while updating the project: {e.Message}");
            }
        }

        public async Task<ProyectoResponse> DeleteAsync(int id)
        {
            var existingProject = await _projectRepository.FindByIdAsync(id);

            if (existingProject == null)
                return new ProyectoResponse("Project not found");
            try
            {
                _projectRepository.Remove(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProyectoResponse(existingProject);
            }
            catch (Exception e)
            {
                return new ProyectoResponse($"An error occurred while deleting project:{e.Message}");
            }
        }
    }
}