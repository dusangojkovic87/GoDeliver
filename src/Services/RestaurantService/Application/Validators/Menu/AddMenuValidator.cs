using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Menu;
using FluentValidation;

namespace Application.Validators.Menu
{
    public class AddMenuValidator : AbstractValidator<AddMenuCommand>
    {
        public AddMenuValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(m => m.Price).NotEmpty().WithMessage("Price cannot be empty!");
            RuleFor(m => m.Price).PrecisionScale(9, 2, true).WithMessage("Price must have 9 digits ,with max 2 digits after! ");
            RuleFor(m => m.RestaurantId).NotEmpty().WithMessage("Restaurant id not passed!");

        }

    }
}