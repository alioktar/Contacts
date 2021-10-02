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
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IPersonService, PersonService>();

            services.AddMapper().AddDataLayer(configuration);
            return services;
        }
    }
}
