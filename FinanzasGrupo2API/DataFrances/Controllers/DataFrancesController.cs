using AutoMapper;
using FinanzasGrupo2API.DatasFrances.Domain.Models;
using FinanzasGrupo2API.DatasFrances.Domain.Services;
using FinanzasGrupo2API.DatasFrances.Resources;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasGrupo2API.DatasFrances.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class DataFrancesController : ControllerBase
    {
        private readonly IDataFrancesService _dataFrancesService;
        private readonly IMapper _mapper;

        public DataFrancesController(IDataFrancesService dataFrancesService, IMapper mapper)
        {
            _dataFrancesService = dataFrancesService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<DataFrancesResource>> GetAllAsync()
        {
            var dataFrancess = await _dataFrancesService.ListAsync();
            var resources = _mapper.Map<IEnumerable<DataFrances>, IEnumerable<DataFrancesResource>>(dataFrancess);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<DataFrancesResource> GetById(int id)
        {
            var dataFrances = await _dataFrancesService.GetById(id);
            var resource = _mapper.Map<DataFrances, DataFrancesResource>(dataFrances);
            return resource;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDataFrancesResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var dataFrancesResult = await _dataFrancesService.SaveAsync(resource);


            if (!dataFrancesResult.Success)
                return BadRequest(dataFrancesResult.Message);

            var dataFrancesResource = _mapper.Map<DataFrances, DataFrancesResource>(dataFrancesResult.Resource);
            return Ok(dataFrancesResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDataFrancesResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var dataFrances = _mapper.Map<SaveDataFrancesResource, DataFrances>(resource);
            var result = await _dataFrancesService.UpdateAsync(id, dataFrances);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var dataFrancesResource = _mapper.Map<DataFrances, DataFrancesResource>(result.Resource);
            return Ok(dataFrancesResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _dataFrancesService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<DataFrances, DataFrancesResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        
    }
}