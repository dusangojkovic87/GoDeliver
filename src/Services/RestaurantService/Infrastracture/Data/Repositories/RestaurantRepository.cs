using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;
using Domain.Models.Restaurant;
using Domain.Repositories;
using Infrastracture.Exceptions;

namespace Infrastracture.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {

        private readonly RestaurantServiceDbContext _context;
        public RestaurantRepository(RestaurantServiceDbContext context)
        {

            _context = context;


        }


        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {

            var restaurants = _context.Restaurants.ToList();
            return await Task.FromResult(restaurants);
        }

        public async Task<bool> AddRestaurant(AddRestaurantDto restaurant)
        {

            var resturantToAAdd = new Restaurant
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                City = restaurant.City,
                State = restaurant.State,
                PostalCode = restaurant.PostalCode,
                Phone = restaurant.Phone,
                Email = restaurant.Email,
                Longitude = restaurant.Longitude,
                Latitude = restaurant.Latitude,
                OpeningTime = restaurant.OpeningTime,
                ClosingTime = restaurant.ClosingTime

            };

            await _context.Restaurants.AddAsync(resturantToAAdd);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }



            return false;
        }

        public async Task<bool> DeleteRestaurantById(DeleteRestauratntByIdDto restaurant)
        {

            var resturantToDelete = _context.Restaurants.FirstOrDefault(r => r.Id.Equals(restaurant.Id));
            if (resturantToDelete == null)
            {
                return false;
            }

            await Task.Run(() => _context.Restaurants.Remove(resturantToDelete));

            var result = await _context.SaveChangesAsync() > 0;

            return result;

        }

        public async Task<GetRestaurantByIdDtoResponce> GetRestaurantById(GetRestaurantByIdDtoRequest restaurant)
        {
            var restaurantFromDb = await _context.Restaurants.FindAsync(restaurant.Id);
            if (restaurantFromDb == null)
            {
                return new GetRestaurantByIdDtoResponce
                {
                    isNullable = true

                };
            }

            return new GetRestaurantByIdDtoResponce
            {
                isNullable = false,
                restaurant = restaurantFromDb
            };
        }
    }
}