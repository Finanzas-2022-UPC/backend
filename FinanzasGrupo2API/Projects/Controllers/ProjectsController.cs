using AutoMapper;
using FinanzasGrupo2API.Projects.Domain.Models;
using FinanzasGrupo2API.Projects.Domain.Services;
using FinanzasGrupo2API.Projects.Resources;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasGrupo2API.Projects.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProjectResource>> GetAllAsync()
        {
            var projects = await _projectService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
            return resources;
            
        }
        
        [HttpGet("{id}")]
        public async Task<ProjectResource> GetById(int id)
        {
            var project = await _projectService.GetById(id);
            var resource = _mapper.Map<Project, ProjectResource>(project);
            return resource;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProjectResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var projectResult = await _projectService.SaveAsync(resource);


            if (!projectResult.Success)
                return BadRequest(projectResult.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(projectResult.Resource);
            return Ok(projectResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProjectResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var project = _mapper.Map<SaveProjectResource, Project>(resource);
            var result = await _projectService.UpdateAsync(id, project);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        
    }
}