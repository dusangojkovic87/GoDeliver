using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Restaurant;
using Application.Validators;
using FluentValidation;

namespace Restaurant.API.Extensions
{
    public static class AddValidatorsExtension
    {

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            //category
            services.AddScoped<IValidator<AddCategoryCommand>, RestaurantCategoryValidator>();
            //restaurant
            services.AddScoped<IValidator<AddRestaurantCommand>, AddRestaurantValidator>();

            return services;

        }

    }
}