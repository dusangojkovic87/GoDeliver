using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using FluentValidation;
using Application.Commands.Restaurant;

namespace Application.Validators
{
    public class AddRestaurantValidator : AbstractValidator<AddRestaurantCommand>
    {
        public AddRestaurantValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name field cannot be empty!");
            RuleFor(r => r.Phone).NotEmpty().WithMessage("Phone field cannot be empty!");
            RuleFor(r => r.City).NotEmpty().WithMessage("City field cannot be empty!");
            RuleFor(r => r.Address).NotEmpty().WithMessage("Address field cannot be empty!");
            RuleFor(r => r.State).NotEmpty().WithMessage("State field cannot be empty!");
            RuleFor(r => r.OpeningTime).NotEmpty().WithMessage("Opening time field cannot be empty!");
            RuleFor(r => r.ClosingTime).NotEmpty().WithMessage("Closint time field cannot be empty!");
            RuleFor(r => r.Email).NotEmpty().WithMessage("Email field cannot be empty!");
            RuleFor(r => r.Email).EmailAddress().WithMessage("Email is not valid!");



        }



    }
}