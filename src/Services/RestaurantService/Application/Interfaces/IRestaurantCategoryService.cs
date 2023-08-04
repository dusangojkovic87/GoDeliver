using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRestaurantCategoryService
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<bool> DoesCategoryExists(Category category);
        Task<bool> DeleteCategoryByIdAsync(int Id);
    }
}