using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRestaurantCategoryRepository
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<bool> DoesCategoryExists(Category category);
        Task<bool> DeleteCategoryAsync(int Id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<bool> UpdateCategory(int Id, Category category);

        Task<bool> DoesCategoryByIdExists(int Id);


    }
}