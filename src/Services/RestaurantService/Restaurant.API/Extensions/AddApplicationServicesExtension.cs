using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Review;
using Application.Services;
using Application.Services.Review;

namespace Restaurant.API.Extensions
{
    public static class AddApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            //category
            service.AddScoped<IRestaurantCategoryService, RestaurantCategoryService>();
            //restaurant
            service.AddScoped<IRestaurantService, Application.Services.RestaurantService>();
            //review
            service.AddScoped<IReviewService, ReviewService>();

            return service;

        }

    }
}