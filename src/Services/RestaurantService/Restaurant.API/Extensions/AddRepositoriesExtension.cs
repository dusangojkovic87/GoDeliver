using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastracture.Data.Repositories;

namespace Restaurant.API.Extensions
{
    public static class AddRepositoriesExtension
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();

            return services;

        }

    }
}