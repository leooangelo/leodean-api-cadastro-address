using Microsoft.AspNetCore.Builder;
using MS.Address.Domain.Middlewares;

namespace MS.Address.Domain.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
