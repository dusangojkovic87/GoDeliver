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
            //category
            services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();
            //restaurant
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();


            return services;

        }

    }
}