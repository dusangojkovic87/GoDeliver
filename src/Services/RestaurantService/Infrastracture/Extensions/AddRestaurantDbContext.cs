using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RestaurantService.Infrastracture.Extensions
{
    public static class AddRestaurantDbContextExtension
    {
        public static IServiceCollection AddRestaurantDbContext(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<RestaurantServiceDbContext>(options => options.UseSqlServer(connectionString));
            return services;

        }

    }
}