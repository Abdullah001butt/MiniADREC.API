using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MiniADREC.Context.DependencyInjection
{
    public static class ContextRegistration
    {
        public static IServiceCollection AddContextLayer(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
