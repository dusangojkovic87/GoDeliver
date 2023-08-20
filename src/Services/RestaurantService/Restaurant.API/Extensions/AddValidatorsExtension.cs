using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Restaurant;
using Application.Commands.Review;
using Application.Handlers.Review;
using Application.Validators;
using Application.Validators.Review;
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
            //review
            services.AddScoped<IValidator<deleteReviewByIdCommand>, DeleteReviewByIdValidator>();
            services.AddScoped<IValidator<updateReviewCommand>, UpdateReviewValidator>();

            return services;

        }

    }
}