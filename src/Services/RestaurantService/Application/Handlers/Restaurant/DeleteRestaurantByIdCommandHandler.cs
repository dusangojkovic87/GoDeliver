using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Restaurant;
using Application.Interfaces;
using Authentication.API.Exceptions;
using Domain.Models.Restaurant;
using MediatR;

namespace Application.Handlers.Restaurant
{
    public class DeleteRestaurantByIdCommandHandler : IRequestHandler<DeleteRestaurantByIdCommand, bool>
    {

        private readonly IRestaurantService _restuarantService;

        public DeleteRestaurantByIdCommandHandler(IRestaurantService restaurantService)
        {
            _restuarantService = restaurantService;

        }



        public async Task<bool> Handle(DeleteRestaurantByIdCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = new DeleteRestauratntByIdDto
            {
                Id = request.Id
            };

            var result = await _restuarantService.DeleteRestaurantByIdAsync(restaurantId);
            return result;

        }
    }
}