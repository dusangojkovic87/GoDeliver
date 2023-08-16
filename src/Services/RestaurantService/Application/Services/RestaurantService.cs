using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Models;
using Domain.Models.Restaurant;
using Domain.Repositories;

namespace Application.Services
{
    public class RestaurantService : IRestaurantService
    {

        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;

        }

        public async Task<bool> AddRestaurantAsync(AddRestaurantDto restaurant)
        {
            var result = await _restaurantRepository.AddRestaurant(restaurant);
            return result;
        }

        public async Task<bool> DeleteRestaurantByIdAsync(DeleteRestauratntByIdDto restaurantId)
        {
            var result = await _restaurantRepository.DeleteRestaurantById(restaurantId);
            return result;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurants();

            return restaurants;
        }
    }
}