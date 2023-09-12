using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Staff;
using Application.Queries.Staff;
using Domain.Models.Staff;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllStaff()
        {

            var request = new GetAllStaffQuery { };

            var result = await _mediator.Send(request);

            return Ok(result);

        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStaffMember([FromRoute] int Id)
        {

            if (Id < 0)
            {
                return BadRequest("Not valid Staff Id");

            }



            var request = new GetStaffMemberQuery
            {
                Id = Id
            };

            var result = await _mediator.Send(request);

            return Ok(result);

        }


        [HttpPost("add")]
        public async Task<IActionResult> AddStaffMember([FromBody] AddStaffMemberRequestDto requestDto)
        {
            var addRequest = new AddStaffMemberCommand
            {
                RestaurantId = requestDto.RestaurantId,
                Name = requestDto.Name,
                Role = requestDto.Role

            };

            var result = await _mediator.Send(addRequest);

            if (!result)
            {
                return BadRequest("Error,member not added!");

            }

            return Ok("Staff member added!");

        }


        [HttpPost("update")]
        public async Task<IActionResult> UpdateStaffMember([FromBody] UpdateStaffMemberRequestDto requestDto)
        {
            var updateRequest = new UpdateStaffMemberCommand
            {
                memberId = requestDto.memberId,
                Name = requestDto.Name,
                Role = requestDto.Role

            };

            var result = await _mediator.Send(updateRequest);

            if (!result)
            {
                return BadRequest("Update failed!");

            }

            return Ok("Staff member updated!");


        }











    }
}