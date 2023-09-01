using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.MenuItem;
using FluentValidation;

namespace Application.Validators.MenuItem
{
    public class AddMenuItemValidator : AbstractValidator<AddMenuItemCommand>
    {
        public AddMenuItemValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name cannot be empty!");
            RuleFor(r => r.Price).NotEmpty().WithMessage("Price cannot be empty!");



        }

    }
}