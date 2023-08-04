using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<bool> DoesCategoryExists(Category category)
        {

            var result = await Task.Run(() => _context.Categories.FirstOrDefault(c => c.Name == category.Name));
            if (result != null)
            {
                return true;
            }

            return false;


        }

        public async Task<bool> DeleteCategoryAsync(int Id)
        {
            var category = await _context.Categories.FindAsync(Id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await Task.Run(() => _context.Categories.ToList());

            return categories;
        }
    }
}