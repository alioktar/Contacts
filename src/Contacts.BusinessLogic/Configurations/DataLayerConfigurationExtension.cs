using Contacts.Core.DataAccess;
using Contacts.Core.DataAccess.EntityFreamework;
using Contacts.DataAccess.Abstract;
using Contacts.DataAccess.Concrete.EntityFreamework;
using Contacts.DataAccess.Concrete.EntityFreamework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.BusinessLogic.Configurations
{
    public static class DataLayerConfigurationExtension
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContactsContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("Default"),
                    builder => builder.MigrationsAssembly(typeof(ContactsContext).Assembly.GetName().Name)));

            services.AddScoped<DbContext>(provider => provider.GetService<ContactsContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
