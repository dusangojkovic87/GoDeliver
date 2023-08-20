using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Review;
using FluentValidation;

namespace Application.Validators.Review
{
    public class UpdateReviewValidator : AbstractValidator<updateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(r => r.Comment).NotEmpty().WithMessage("Comment cannot be empty!");
            RuleFor(r => r.Rating).NotEmpty().WithMessage("Rating cannot be empty!");


        }

    }
}