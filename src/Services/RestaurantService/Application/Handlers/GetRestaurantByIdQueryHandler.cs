using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Queries.Restaurant;
using Authentication.API.Exceptions;
using Domain.Models.Restaurant;
using MediatR;

namespace Application.Handlers
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, Domain.Entities.Restaurant>
    {

        private readonly IRestaurantService _restaurantService;

        public GetRestaurantByIdQueryHandler(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;

        }



        public async Task<Domain.Entities.Restaurant> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            var getRestaurantRequest = new GetRestaurantByIdDtoRequest
            {
                Id = request.Id

            };

            var result = await _restaurantService.GetRestaurantByIdAsync(getRestaurantRequest);

            if (result.isNullable)
            {
                throw new CustomValidationException(new List<string> { "Restauraunt not found!" });

            }


            return result.restaurant;



        }
    }
}