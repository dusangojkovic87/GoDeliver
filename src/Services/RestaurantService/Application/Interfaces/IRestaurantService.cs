using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Restaurant;
using Domain.Entities;
using Domain.Models;
using Domain.Models.Restaurant;

namespace Application.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<bool> AddRestaurantAsync(AddRestaurantDto restaurant);
        Task<bool> DeleteRestaurantByIdAsync(DeleteRestauratntByIdDto restaurantId);
        Task<GetRestaurantByIdDtoResponce> GetRestaurantByIdAsync(GetRestaurantByIdDtoRequest request);
    }
}