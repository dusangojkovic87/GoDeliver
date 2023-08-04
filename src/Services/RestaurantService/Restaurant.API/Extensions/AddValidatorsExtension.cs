using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Validators;
using FluentValidation;

namespace Restaurant.API.Extensions
{
    public static class AddValidatorsExtension
    {

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AddCategoryCommand>, RestaurantCategoryValidator>();

            return services;

        }

    }
}