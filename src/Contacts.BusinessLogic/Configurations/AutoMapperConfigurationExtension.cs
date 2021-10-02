using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.BusinessLogic.Configurations
{
    public static class AutoMapperConfigurationExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var profiles = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            assemblies.ForEach(
                assemble => profiles.AddRange(assemble.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic).ToList()));

            services.AddAutoMapper(profiles.ToArray());
            return services;
        }
    }
}
