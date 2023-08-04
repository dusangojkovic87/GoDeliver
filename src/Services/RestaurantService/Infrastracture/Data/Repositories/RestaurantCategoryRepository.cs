using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastracture.Data.Repositories
{


    public class RestaurantCategoryRepository : IRestaurantCategoryRepository
    {

        private readonly RestaurantServiceDbContext _context;
        public RestaurantCategoryRepository(RestaurantServiceDbContext context)
        {
            _context = context;

        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }


    }
}