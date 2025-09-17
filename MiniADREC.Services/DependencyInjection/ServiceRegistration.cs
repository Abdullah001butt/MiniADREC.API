using Microsoft.Extensions.DependencyInjection;
using MiniADREC.Services.Implementations;
using MiniADREC.Services.Interfaces;
using MiniADREC.Services.Mappings;

namespace MiniADREC.Services.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPlotService, PlotService>();
            services.AddScoped<IPermitRequestService, PermitRequestService>();

            return services;
        }
    }
}
