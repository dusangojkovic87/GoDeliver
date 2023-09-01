using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.MenuItem;
using FluentValidation;

namespace Application.Validators.MenuItem
{
    public class UpdateMenuItemValidator : AbstractValidator<UpdateMenuItemCommand>
    {
        public UpdateMenuItemValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name cannot be empty!");
            RuleFor(r => r.Price).NotEmpty().WithMessage("Price cannot be empty!");

        }

    }
}