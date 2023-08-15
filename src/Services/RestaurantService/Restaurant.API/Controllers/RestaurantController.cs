using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Restaurant;
using Application.Queries.Restaurants;
using Authentication.API.Exceptions;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {

        private readonly IMediator _mediatr;
        public RestaurantController(IMediator mediator)
        {
            _mediatr = mediator;


        }



        [HttpPost("add")]
        public async Task<IActionResult> AddRestaurant(AddRestaurantDto restaurantModel)
        {


            var request = new AddRestaurantCommand
            {
                Name = restaurantModel.Name,
                Address = restaurantModel.Address,
                City = restaurantModel.City,
                State = restaurantModel.State,
                PostalCode = restaurantModel.PostalCode,
                Phone = restaurantModel.Phone,
                Email = restaurantModel.Email,
                Longitude = restaurantModel.Longitude,
                Latitude = restaurantModel.Latitude,
                OpeningTime = restaurantModel.OpeningTime,
                ClosingTime = restaurantModel.ClosingTime

            };


            var result = await _mediatr.Send(request);

            return Ok(result);

        }



        [HttpGet("all")]
        public async Task<IActionResult> GetAllRestaurants()
        {

            var request = new GetAllRestaurantQuery { };

            var restaurants = await _mediatr.Send(request);

            return Ok(restaurants);

        }


    }
}