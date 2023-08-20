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
        public async Task<IActionResult> DeleteReview(int Id)
        {

            var loggedUserEmail = User.FindFirst(ClaimTypes.Email).Value;

            var deleteReviewRequest = new deleteReviewByIdCommand
            {
                Id = Id,
                userEmail = loggedUserEmail

            };

            var result = await _mediator.Send(deleteReviewRequest);

            if (!result)
            {
                return BadRequest("Error,review not deleted!");

            }

            var response = new
            {
                Message = "Review deleted!"
            };

            return Ok(response);





        }





    }
}