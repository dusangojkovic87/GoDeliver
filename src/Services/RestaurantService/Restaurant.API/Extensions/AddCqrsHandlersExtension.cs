using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Menu;
using Application.Commands.MenuItem;
using Application.Commands.Restaurant;
using Application.Commands.Review;
using Application.Commands.Staff;
using Application.Commands.Table;
using Application.Handlers;
using Application.Handlers.Menu;
using Application.Handlers.MenuItem;
using Application.Handlers.Restaurant;
using Application.Handlers.Restaurants;
using Application.Handlers.Review;
using Application.Handlers.Staff;
using Application.Handlers.Table;
using Application.Queries;
using Application.Queries.MenuItem;
using Application.Queries.Restaurant;
using Application.Queries.Restaurants;
using Application.Queries.Review;
using Application.Queries.Staff;
using Application.Validators.Menu;
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
            service.AddScoped<IRequestHandler<UpdateTableCommand, bool>, UpdateTableCommandHandler>();
            service.AddScoped<IRequestHandler<DeleteTableCommand, bool>, DeleteTableCommandHandler>();
            //menu
            service.AddScoped<IRequestHandler<AddMenuCommand, bool>, AddMenuCommandHandler>();
            service.AddScoped<IRequestHandler<UpdateMenuCommand, bool>, UpdateMenuCommandHandler>();
            service.AddScoped<IRequestHandler<DeleteMenuCommand, bool>, DeleteMenuCommandHandler>();
            //menuitem
            service.AddScoped<IRequestHandler<AddMenuItemCommand, bool>, AddMenuItemCommandHandler>();
            service.AddScoped<IRequestHandler<DeleteMenuItemCommand, bool>, DeleteMenuItemCommandHandler>();
            service.AddScoped<IRequestHandler<UpdateMenuItemCommand, bool>, UpdateMenuItemCommandHandler>();
            service.AddScoped<IRequestHandler<GetAllMenuItemsQuery, IEnumerable<Domain.Entities.MenuItem>>, GetAllMenuItemsQueryHandler>();
            service.AddScoped<IRequestHandler<GetMenuItemByIdQuery, Domain.Entities.MenuItem>, GetMenuItemByIdQueryHandler>();
            //staff
            service.AddScoped<IRequestHandler<GetAllStaffQuery, IEnumerable<Domain.Entities.Staff>>, GetStaffQueryHandler>();
            service.AddScoped<IRequestHandler<GetStaffMemberQuery, Domain.Entities.Staff>, GetStaffMemberQueryHandler>();
            service.AddScoped<IRequestHandler<AddStaffMemberCommand, bool>, AddStaffMemberCommandHandler>();
            return service;

        }

    }
}