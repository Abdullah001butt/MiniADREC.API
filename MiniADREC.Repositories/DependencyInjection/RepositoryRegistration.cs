using Microsoft.Extensions.DependencyInjection;
using MiniADREC.Repositories.Implementations;
using MiniADREC.Repositories.Interfaces;

namespace MiniADREC.Repositories.DependencyInjection
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IPlotRepository, PlotRepository>();
            services.AddScoped<IPermitRequestRepository, PermitRequestRepository>();

            return services;
        }
    }
}
