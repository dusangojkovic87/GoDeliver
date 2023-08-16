using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;
using Domain.Models.Restaurant;

namespace Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
        Task<bool> AddRestaurant(AddRestaurantDto restaurant);
        Task<bool> DeleteRestaurantById(DeleteRestauratntByIdDto restaurant);
        Task<GetRestaurantByIdDtoResponce> GetRestaurantById(GetRestaurantByIdDtoRequest restaurant);
    }
}