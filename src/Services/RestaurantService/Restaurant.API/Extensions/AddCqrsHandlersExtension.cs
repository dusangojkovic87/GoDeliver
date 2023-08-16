using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Restaurant;
using Application.Handlers;
using Application.Handlers.Restaurant;
using Application.Handlers.Restaurants;
using Application.Queries;
using Application.Queries.Restaurant;
using Application.Queries.Restaurants;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Restaurant.API.Extensions
{
    public static class AddCqrsHandlersExtension
    {

        public static IServiceCollection AddCqrsHandlers(this IServiceCollection service)
        {

            service.AddScoped<IRequestHandler<AddCategoryCommand, Category>, AddCategoryCommandHandler>();
            service.AddScoped<IRequestHandler<DeleteCategoryCommand, bool>, DeleteCategoryCommandHandler>();
            service.AddScoped<IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>, GetAllCategoriesQueryHandler>();
            service.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, UpdateCategoryCommandHandler>();

            //restaurant handlers

            service.AddScoped<IRequestHandler<GetAllRestaurantQuery, IEnumerable<Domain.Entities.Restaurant>>, GetAllRestaurantQueryHandler>();
            service.AddScoped<IRequestHandler<AddRestaurantCommand, AddRestaurantDto>, AddRestaurantCommandHandler>();
            service.AddScoped<IRequestHandler<DeleteRestaurantByIdCommand, bool>, DeleteRestaurantByIdCommandHandler>();
            service.AddScoped<IRequestHandler<GetRestaurantByIdQuery, Domain.Entities.Restaurant>, GetRestaurantByIdQueryHandler>();
            return service;

        }

    }
}