using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Menu;
using FluentValidation;

namespace Application.Validators.Menu
{
    public class UpdateMenuValidator : AbstractValidator<UpdateMenuCommand>
    {

        public UpdateMenuValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name cannot be empty!");
            RuleFor(m => m.Price).NotEmpty().WithMessage("Price cannot be empty!");
            RuleFor(m => m.Price).PrecisionScale(18, 2, true).WithMessage("Price max is in format 18,2");



        }

    }
}