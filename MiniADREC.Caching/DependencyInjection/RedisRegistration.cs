using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniADREC.Caching.Implementations;
using MiniADREC.Caching.Interfaces;

namespace MiniADREC.Caching.DependencyInjection
{
    public static class RedisRegistration
    {
        public static IServiceCollection AddRedisCaching(this IServiceCollection services, IConfiguration config)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config.GetConnectionString("Redis");
                options.InstanceName = "MiniADREC:";
            });

            services.AddScoped<IRedisCacheService, RedisCacheService>();

            return services;
        }
    }
}
