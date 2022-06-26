using AutoMapper;
using FinanzasGrupo2API.Movimientos.Domain.Models;
using FinanzasGrupo2API.Movimientos.Domain.Services;
using FinanzasGrupo2API.Movimientos.Resources;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasGrupo2API.Movimientos.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;
        private readonly IMapper _mapper;

        public MovimientosController(IMovimientoService movimientoService, IMapper mapper)
        {
            _movimientoService = movimientoService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<MovimientoResource>> GetAllAsync([FromQuery] int ?movimientoType)
        {
            var movimientos = await _movimientoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Movimiento>, IEnumerable<MovimientoResource>>(movimientos);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<MovimientoResource> GetById(int id)
        {
            var movimiento = await _movimientoService.GetById(id);
            var resource = _mapper.Map<Movimiento, MovimientoResource>(movimiento);
            return resource;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMovimientoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var movimientoResult = await _movimientoService.SaveAsync(resource);


            if (!movimientoResult.Success)
                return BadRequest(movimientoResult.Message);

            var movimientoResource = _mapper.Map<Movimiento, MovimientoResource>(movimientoResult.Resource);
            return Ok(movimientoResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMovimientoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var movimiento = _mapper.Map<SaveMovimientoResource, Movimiento>(resource);
            var result = await _movimientoService.UpdateAsync(id, movimiento);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var movimientoResource = _mapper.Map<Movimiento, MovimientoResource>(result.Resource);
            return Ok(movimientoResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _movimientoService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Movimiento, MovimientoResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        
    }
}