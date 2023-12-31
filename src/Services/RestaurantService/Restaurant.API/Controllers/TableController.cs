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


        [HttpPost("update/{tableId}")]
        public async Task<IActionResult> UpdateTable(int tableId, updateTableRequestDto requestDto)
        {

            var request = new UpdateTableCommand
            {
                Id = tableId,
                SeatingCapacity = requestDto.SeatingCapacity,
                TableNumber = requestDto.TableNumber

            };

            var result = await _mediator.Send(request);

            if (!result)
            {
                return BadRequest("Error,table not updated!");

            }

            return Ok("Table updated!");



        }


        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteTable(int Id)
        {

            var deleteTableRequest = new DeleteTableCommand
            {
                Id = Id
            };

            var result = await _mediator.Send(deleteTableRequest);

            if (!result)
            {
                return BadRequest("Error,table not deleted!");

            }

            return Ok("Table deleted");



        }




    }
}