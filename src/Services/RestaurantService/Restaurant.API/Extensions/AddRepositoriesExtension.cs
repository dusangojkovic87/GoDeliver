using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Repositories.Review;
using Infrastracture.Data.Repositories;
using Infrastracture.Data.Repositories.Review;

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
            //review
            services.AddScoped<IReviewRepository, ReviewRepository>();


            return services;

        }

    }
}