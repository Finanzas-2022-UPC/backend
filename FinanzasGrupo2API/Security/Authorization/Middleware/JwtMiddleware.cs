using System.Linq;
using System.Threading.Tasks;
using FinanzasGrupo2API.Security.Authorization.Handlers.Interfaces;
using FinanzasGrupo2API.Security.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace FinanzasGrupo2API.Security.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;


        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();
            
            var userId = handler.ValidateToken(token);
            
            if (userId != null)
                // Attach User to context
                context.Items["User"] = await userService.GetByIdAsync(userId.Value);
            
            await _next(context);
        }
    }
}