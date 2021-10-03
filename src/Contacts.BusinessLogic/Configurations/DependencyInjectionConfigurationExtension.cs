using Contacts.BusinessLogic.Services.Abstract;
using Contacts.BusinessLogic.Services.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.BusinessLogic.Configurations
{
    public static class DependencyInjectionConfigurationExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayer(configuration).AddMapper();

            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IPersonService, PersonService>();

            return services;
        }
    }
}
