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
    public class DeleteReviewByIdCommandHandler : IRequestHandler<deleteReviewByIdCommand, bool>
    {

        private readonly IReviewService _reviewServise;
        private readonly IValidator<deleteReviewByIdCommand> _validator;

        public DeleteReviewByIdCommandHandler(IReviewService reviewService, IValidator<deleteReviewByIdCommand> validator)
        {
            _reviewServise = reviewService;
            _validator = validator;

        }


        public async Task<bool> Handle(deleteReviewByIdCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }

            var review = new deleteReviewRequestDto
            {
                Id = request.Id

            };

            var result = await _reviewServise.DeleteReviewByIdAsync(review);
            return result;

        }
    }
}