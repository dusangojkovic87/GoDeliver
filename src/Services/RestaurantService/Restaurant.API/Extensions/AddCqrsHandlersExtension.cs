using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Handlers;
using Application.Queries;
using Domain.Entities;
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

            return service;

        }

    }
}