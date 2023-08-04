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
    }
}