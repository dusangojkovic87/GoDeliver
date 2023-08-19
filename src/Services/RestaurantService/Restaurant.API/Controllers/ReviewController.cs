using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Commands.Review;
using Domain.Models.Review;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.API.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("add/{Id}")]
        public async Task<IActionResult> AddReview(int Id, [FromBody] AddReviewRequestDto request)
        {

            var command = new AddReviewCommand
            {
                RestaurantId = Id,
                UserName = request.UserName,
                Comment = request.Comment,
                DatePosted = DateTime.Now,
                Rating = request.Rating

            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest("Error,review not added!");
            }

            string message = "Review added";

            return Ok(message);

        }


        [Authorize]
        [HttpDelete("delete/{Id}")]
        public IActionResult DeleteReview([FromQuery] deleteReviewRequestDto request)
        {


            var user = User.FindFirst(ClaimTypes.NameIdentifier);

            return Ok(user.Value);





        }





    }
}