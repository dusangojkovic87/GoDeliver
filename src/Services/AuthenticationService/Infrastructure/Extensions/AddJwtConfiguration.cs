using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Contracts;

namespace Infrastructure.Extensions
{
    public static class AddJwtConfigurationExtension
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IJwtConfig jwtConfig)
        {
            services.AddSingleton<IJwtConfig>(jwtConfig);
            return services;

        }

    }
}

