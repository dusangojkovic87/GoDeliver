using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Review;
using Application.Interfaces.Review;
using Authentication.API.Exceptions;
using Domain.Entities;
using Domain.Models.Review;
using MediatR;

namespace Application.Handlers.Review
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, bool>
    {
        private readonly IReviewService _reviewService;

        public AddReviewCommandHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;

        }


        public async Task<bool> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var reviewDto = new AddReviewRequestDto
            {
                RestaurantId = request.RestaurantId,
                UserName = request.UserName,
                Comment = request.Comment,
                DatePosted = request.DatePosted,
                Rating = request.Rating

            };

            var result = await _reviewService.AddReviewAsync(reviewDto);

            if (!result)
            {
                throw new CustomValidationException(new List<string> { "Error,review not added!" });

            }

            return result;
        }
    }
}