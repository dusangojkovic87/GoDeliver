using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Repositories.Menu;
using Domain.Repositories.MenuItem;
using Domain.Repositories.Review;
using Domain.Repositories.Staff;
using Domain.Repositories.Table;
using Infrastracture.Data.Repositories;
using Infrastracture.Data.Repositories.Menu;
using Infrastracture.Data.Repositories.MenuItem;
using Infrastracture.Data.Repositories.Review;
using Infrastracture.Data.Repositories.Staff;
using Infrastracture.Data.Repositories.Table;

namespace Restaurant.API.Extensions
{
    public static class AddRepositoriesExtension
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //category
            services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();
            //restaurant
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            //review
            services.AddScoped<IReviewRepository, ReviewRepository>();
            //table
            services.AddScoped<ITableRepository, TableRepository>();
            //menu
            services.AddScoped<IMenuRepository, MenuRepository>();
            //menuitem
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            //staff
            services.AddScoped<IStaffRepository, StaffRepository>();




            return services;

        }

    }
}