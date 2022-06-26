using AutoMapper;
using FinanzasGrupo2API.Cruds.Domain.Models;
using FinanzasGrupo2API.Cruds.Domain.Services;
using FinanzasGrupo2API.Cruds.Resources;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasGrupo2API.Cruds.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CrudsController : ControllerBase
    {
        private readonly ICrudService _crudService;
        private readonly IMapper _mapper;

        public CrudsController(ICrudService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CrudResource>> GetAllAsync([FromQuery] string ?crud, [FromQuery] int ?projectId)
        {
            var cruds = await _crudService.ListAsync(crud, projectId);
            var resources = _mapper.Map<IEnumerable<Crud>, IEnumerable<CrudResource>>(cruds);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<CrudResource> GetById(int id)
        {
            var crud = await _crudService.GetById(id);
            var resource = _mapper.Map<Crud, CrudResource>(crud);
            return resource;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCrudResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var crudResult = await _crudService.SaveAsync(resource);


            if (!crudResult.Success)
                return BadRequest(crudResult.Message);

            var crudResource = _mapper.Map<Crud, CrudResource>(crudResult.Resource);
            return Ok(crudResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCrudResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var crud = _mapper.Map<SaveCrudResource, Crud>(resource);
            var result = await _crudService.UpdateAsync(id, crud);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var crudResource = _mapper.Map<Crud, CrudResource>(result.Resource);
            return Ok(crudResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _crudService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Crud, CrudResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        
    }
}