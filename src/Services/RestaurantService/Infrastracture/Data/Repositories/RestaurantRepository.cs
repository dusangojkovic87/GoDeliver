using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;
using Domain.Repositories;

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
    }
}