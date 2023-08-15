using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries.Restaurants;
using MediatR;
using Domain.Entities;
using Application.Interfaces;

namespace Application.Handlers.Restaurants
{
    public class GetAllRestaurantQueryHandler : IRequestHandler<GetAllRestaurantQuery, IEnumerable<Domain.Entities.Restaurant>>
    {

        private readonly IRestaurantService _restaurantService;

        public GetAllRestaurantQueryHandler(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;

        }


        public async Task<IEnumerable<Domain.Entities.Restaurant>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();

            return restaurants;
        }
    }
}