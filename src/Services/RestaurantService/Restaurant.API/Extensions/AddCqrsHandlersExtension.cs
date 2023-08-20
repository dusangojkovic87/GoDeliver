using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Restaurant;
using Application.Commands.Review;
using Application.Commands.Table;
using Application.Handlers;
using Application.Handlers.Restaurant;
using Application.Handlers.Restaurants;
using Application.Handlers.Review;
using Application.Handlers.Table;
using Application.Queries;
using Application.Queries.Restaurant;
using Application.Queries.Restaurants;
using Application.Queries.Review;
using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Restaurant.API.Extensions
{
    public static class AddCqrsHandlersExtension
    {

        public static IServiceCollection AddCqrsHandlers(this IServiceCollection service)
        {
            //category handlers
            service.AddScoped<IRequestHandler<AddCategoryCommand, Category>, AddCategoryCommandHandler>();
            service.AddScoped<IRequestHandler<DeleteCategoryCommand, bool>, DeleteCategoryCommandHandler>();
            service.AddScoped<IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>, GetAllCategoriesQueryHandler>();
            service.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, UpdateCategoryCommandHandler>();
            //restaurant handlers
            service.AddScoped<IRequestHandler<GetAllRestaurantQuery, IEnumerable<Domain.Entities.Restaurant>>, GetAllRestaurantQueryHandler>();
            service.AddScoped<IRequestHandler<AddRestaurantCommand, AddRestaurantDto>, AddRestaurantCommandHandler>();
            service.AddScoped<IRequestHandler<DeleteRestaurantByIdCommand, bool>, DeleteRestaurantByIdCommandHandler>();
            service.AddScoped<IRequestHandler<GetRestaurantByIdQuery, Domain.Entities.Restaurant>, GetRestaurantByIdQueryHandler>();
            //review handlers
            service.AddScoped<IRequestHandler<AddReviewCommand, bool>, AddReviewCommandHandler>();
            service.AddScoped<IRequestHandler<deleteReviewByIdCommand, bool>, DeleteReviewByIdCommandHandler>();
            service.AddScoped<IRequestHandler<updateReviewCommand, bool>, UpdateReviewCommandHandler>();
            service.AddScoped<IRequestHandler<GetReviewsByRestaurantIdQuery, IEnumerable<Domain.Entities.Review>>, GetReviewsByRestaurantIdQueryHandler>();
            //table
            service.AddScoped<IRequestHandler<AddTableToRestaurantCommand, bool>, AddTableCommandHandler>();
            return service;

        }

    }
}