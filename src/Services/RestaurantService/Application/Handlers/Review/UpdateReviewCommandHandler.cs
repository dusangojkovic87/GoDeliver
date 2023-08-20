using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Review;
using Application.Interfaces.Review;
using Authentication.API.Exceptions;
using Domain.Models.Review;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Review
{
    public class UpdateReviewCommandHandler : IRequestHandler<updateReviewCommand, bool>
    {

        private readonly IReviewService _reviewService;
        private readonly IValidator<updateReviewCommand> _validator;

        public UpdateReviewCommandHandler(IReviewService reviewService, IValidator<updateReviewCommand> validator)
        {
            _reviewService = reviewService;
            _validator = validator;

        }



        public async Task<bool> Handle(updateReviewCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }

            var updateReview = new updateReviewRequestDto
            {
                Id = request.Id,
                Comment = request.Comment,
                Rating = request.Rating,
                UserName = request.UserName

            };

            var result = await _reviewService.UpdateReviewAsync(updateReview);

            return result;
        }
    }
}