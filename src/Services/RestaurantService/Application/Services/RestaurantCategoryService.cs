using System;
using System.Collections.Generic;
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


    }
}