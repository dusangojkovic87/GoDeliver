using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Restaurant;
using Application.Interfaces;
using Authentication.API.Exceptions;
using Domain.Entities;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Restaurant
{
    public class AddRestaurantCommandHandler : IRequestHandler<AddRestaurantCommand, AddRestaurantDto>
    {
        private readonly IRestaurantService _restaurantService;
        private IValidator<AddRestaurantCommand> _validator;

        public AddRestaurantCommandHandler(IRestaurantService restaurantService, IValidator<AddRestaurantCommand> validator)
        {
            _restaurantService = restaurantService;
            _validator = validator;

        }




        public async Task<AddRestaurantDto> Handle(AddRestaurantCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }

            var restaurant = new AddRestaurantDto
            {
                Name = request.Name,
                Address = request.Address,
                City = request.City,
                State = request.State,
                PostalCode = request.PostalCode,
                Phone = request.Phone,
                Email = request.Email,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                OpeningTime = request.OpeningTime,
                ClosingTime = request.ClosingTime

            };

            var result = await _restaurantService.AddRestaurantAsync(restaurant);

            if (result == false)
            {
                throw new CustomValidationException(new List<string> { "Error adding Restaurant to db!" });

            }

            return restaurant;



        }
    }
}