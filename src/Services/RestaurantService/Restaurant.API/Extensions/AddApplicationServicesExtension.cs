using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Menu;
using Application.Interfaces.MenuItem;
using Application.Interfaces.Review;
using Application.Interfaces.Staff;
using Application.Interfaces.Table;
using Application.Services;
using Application.Services.Menu;
using Application.Services.MenuItem;
using Application.Services.Review;
using Application.Services.Staff;
using Application.Services.Table;

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
            //table
            service.AddScoped<ITableService, TableService>();
            //menu
            service.AddScoped<IMenuService, MenuService>();
            //menuitem
            service.AddScoped<IMenuItemService, MenuItemService>();
            //staff
            service.AddScoped<IStaffService, StaffService>();

            return service;

        }

    }
}