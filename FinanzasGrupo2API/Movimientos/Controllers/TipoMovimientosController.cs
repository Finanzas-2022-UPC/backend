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
    public class TipoMovimientosController : ControllerBase
    {
        private readonly ITipoMovimientoService _tipoMovimientoService;
        private readonly IMapper _mapper;

        public TipoMovimientosController(ITipoMovimientoService tipoMovimientoService, IMapper mapper)
        {
            _tipoMovimientoService = tipoMovimientoService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<TìpoMovimientoResource>> GetAllAsync()
        {
            var tipoMovimiento = await _tipoMovimientoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TipoMovimiento>, IEnumerable<TìpoMovimientoResource>>(tipoMovimiento);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<TìpoMovimientoResource> GetById(int id)
        {
            var tipoMovimiento = await _tipoMovimientoService.GetById(id);
            var resource = _mapper.Map<TipoMovimiento, TìpoMovimientoResource>(tipoMovimiento);
            return resource;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTipoMovimientoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tipoMovimientoResult = await _tipoMovimientoService.SaveAsync(resource);


            if (!tipoMovimientoResult.Success)
                return BadRequest(tipoMovimientoResult.Message);

            var movimientoResource = _mapper.Map<TipoMovimiento, TìpoMovimientoResource>(tipoMovimientoResult.Resource);
            return Ok(movimientoResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTipoMovimientoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tipoMovimiento = _mapper.Map<SaveTipoMovimientoResource, TipoMovimiento>(resource);
            var result = await _tipoMovimientoService.UpdateAsync(id, tipoMovimiento);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var movimientoResource = _mapper.Map<TipoMovimiento, TìpoMovimientoResource>(result.Resource);
            return Ok(movimientoResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _tipoMovimientoService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<TipoMovimiento, TìpoMovimientoResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        
    }
}