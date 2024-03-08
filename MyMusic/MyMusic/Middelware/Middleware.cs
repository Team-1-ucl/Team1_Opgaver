using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MyMusic.Services;
using System.Threading.Tasks;

namespace MyMusic.Middelware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly IService _service;

        public Middleware(RequestDelegate next, IService service) // Den skal kalde på service
        {
            _next = next;
            _service = service;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments(new PathString("/Album/Index")))
            {
                _service.Increment();
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseJustinsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
