using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.Data.Repositories;

namespace Authentication.API.Extensions
{
    public static class AddRepositoriesExtension
    {

        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {

            service.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
            return service;

        }

    }
}