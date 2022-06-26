using AutoMapper;
using FinanzasGrupo2API.Bonos.Domain.Models;
using FinanzasGrupo2API.Bonos.Domain.Services;
using FinanzasGrupo2API.Bonos.Resources;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasGrupo2API.Bonos.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class BonosController : ControllerBase
    {
        private readonly IBonoService _bonoService;
        private readonly IMapper _mapper;

        public BonosController(IBonoService bonoService, IMapper mapper)
        {
            _bonoService = bonoService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<BonoResource>> GetAllAsync([FromQuery] int ?bonoType)
        {
            var bonos = await _bonoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Bono>, IEnumerable<BonoResource>>(bonos);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<BonoResource> GetById(int id)
        {
            var bono = await _bonoService.GetById(id);
            var resource = _mapper.Map<Bono, BonoResource>(bono);
            return resource;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBonoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var bonoResult = await _bonoService.SaveAsync(resource);


            if (!bonoResult.Success)
                return BadRequest(bonoResult.Message);

            var bonoResource = _mapper.Map<Bono, BonoResource>(bonoResult.Resource);
            return Ok(bonoResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBonoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var bono = _mapper.Map<SaveBonoResource, Bono>(resource);
            var result = await _bonoService.UpdateAsync(id, bono);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var bonoResource = _mapper.Map<Bono, BonoResource>(result.Resource);
            return Ok(bonoResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _bonoService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Bono, BonoResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        
    }
}