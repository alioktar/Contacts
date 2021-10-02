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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ContactsContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly(typeof(ContactsContext).Assembly.FullName)));

            return services;
        }
    }
}
