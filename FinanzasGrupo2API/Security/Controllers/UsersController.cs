using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinanzasGrupo2API.Security.Authorization.Attributes;
using FinanzasGrupo2API.Security.Domain.Services;
using FinanzasGrupo2API.Security.Domain.Services.Communication;
using FinanzasGrupo2API.Security.Resources;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasGrupo2API.Security.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        [AllowAnonymous]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate( AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("auth/sign-up")]
        public async Task<IActionResult> Register( RegisterRequest request)
        {
            await _userService.RegisterAsync(request);
            return Ok(new {message = "Registration successful."});
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<UserResource>>(users);
            return resources;
        }
        
        /*
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, Domain.Models.User>(resource);
            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Domain.Models.User, UserResource>(result.Resource);
            return Ok(productResource);
        }
        */
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, Domain.Models.User>(resource);
            var result = await _userService.UpdateAsync(id, user);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<Domain.Models.User, UserResource>(result.Resource);
            return Ok(userResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Domain.Models.User, UserResource>(result.Resource);
            return Ok(productResource);
        }
    }
}