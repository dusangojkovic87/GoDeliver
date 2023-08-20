using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Table;
using Domain.Models.Table;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TableController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("add/{Id}")]
        public async Task<IActionResult> AddTableToRestaurant(int Id, AddTableToRestaurantRequestDto requestDto)
        {

            var request = new AddTableToRestaurantCommand
            {
                RestaurantId = Id,
                TableNumber = requestDto.TableNumber,
                SeatingCapacity = requestDto.SeatingCapacity

            };

            var result = await _mediator.Send(request);

            if (!result)
            {
                return BadRequest("Error,table not added");

            }

            return Ok("table added!");

        }

    }
}