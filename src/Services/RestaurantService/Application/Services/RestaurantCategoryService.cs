using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class RestaurantCategoryService : IRestaurantCategoryService
    {
        private readonly IRestaurantCategoryRepository _restaurantCategoryRepository;
        public RestaurantCategoryService(IRestaurantCategoryRepository restaurantCategoryRepository)
        {
            _restaurantCategoryRepository = restaurantCategoryRepository;


        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            var result = await _restaurantCategoryRepository.AddCategoryAsync(category);
            return result;

        }

        public async Task<bool> DoesCategoryExists(Category category)
        {
            var result = await _restaurantCategoryRepository.DoesCategoryExists(category);

            return result;

        }

        public async Task<bool> DeleteCategoryByIdAsync(int Id)
        {
            var result = await _restaurantCategoryRepository.DeleteCategoryAsync(Id);
            return result;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {

            var categories = await _restaurantCategoryRepository.GetAllCategories();
            return categories;
        }

        public async Task<bool> FindCategoryByIdAsync(int Id)
        {
            var exists = await _restaurantCategoryRepository.DoesCategoryByIdExists(Id);
            return exists;
        }

        public async Task<bool> UpdateCategoryAsync(int Id, Category category)
        {
            var result = await _restaurantCategoryRepository.UpdateCategory(Id, category);
            return result;
        }
    }
}