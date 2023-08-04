using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class RestaurantCategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        public RestaurantCategoryValidator()
        {
            RuleFor(Category => Category.Name).NotEmpty().WithMessage("Category name required!");
        }

    }
}