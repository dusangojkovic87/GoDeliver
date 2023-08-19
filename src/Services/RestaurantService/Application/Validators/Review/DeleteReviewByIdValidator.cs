using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Review;
using FluentValidation;

namespace Application.Validators.Review
{
    public class DeleteReviewByIdValidator : AbstractValidator<deleteReviewByIdCommand>
    {

        public DeleteReviewByIdValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage("Id not passed!");

        }

    }
}