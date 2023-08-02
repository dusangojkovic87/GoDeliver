using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class AuthDbContextExtension
    {
        public static IServiceCollection AddAuthenticationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuthenticationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
