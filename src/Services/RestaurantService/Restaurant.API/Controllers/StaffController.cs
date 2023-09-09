using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries.Staff;
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



    }
}