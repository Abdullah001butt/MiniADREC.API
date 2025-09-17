using Microsoft.AspNetCore.Builder;

namespace MiniADREC.Common.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Middleware.ErrorHandlingMiddleware>();
        }
    }
}
