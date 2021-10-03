using Contacts.Core.CrossCuttingConcerns.Caching;
using Contacts.Core.CrossCuttingConcerns.Caching.Redis;
using Contacts.Core.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis"];
            });
            services.AddSingleton<ICacheManager, RedisCacheManager>();

            return ServiceTool.Create(services);
        }
    }
}
