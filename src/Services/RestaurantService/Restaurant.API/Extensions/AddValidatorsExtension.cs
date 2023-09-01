using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Menu;
using Application.Commands.MenuItem;
using Application.Commands.Restaurant;
using Application.Commands.Review;
using Application.Commands.Table;
using Application.Handlers.Review;
using Application.Validators;
using Application.Validators.Menu;
using Application.Validators.MenuItem;
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
            //table
            services.AddScoped<IValidator<UpdateTableCommand>, UpdateTableValidator>();
            //menu
            services.AddScoped<IValidator<AddMenuCommand>, AddMenuValidator>();
            services.AddScoped<IValidator<UpdateMenuCommand>, UpdateMenuValidator>();
            //menuItem
            services.AddScoped<IValidator<AddMenuItemCommand>, AddMenuItemValidator>();
            services.AddScoped<IValidator<UpdateMenuItemCommand>, UpdateMenuItemValidator>();

            return services;

        }

    }
}