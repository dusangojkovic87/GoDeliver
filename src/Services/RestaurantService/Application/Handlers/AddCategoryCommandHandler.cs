using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Interfaces;
using Authentication.API.Exceptions;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Handlers
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Category>
    {
        private readonly IRestaurantCategoryService _restaurantCategoryService;
        private readonly IValidator<AddCategoryCommand> _validator;
        public AddCategoryCommandHandler(IRestaurantCategoryService restaurantCategoryService, IValidator<AddCategoryCommand> validator)
        {
            _restaurantCategoryService = restaurantCategoryService;
            _validator = validator;

        }
        public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }





            var categoryToAppend = new Category
            {
                Name = request.Name
            };

            //check if category exists
            var categoryExists = await _restaurantCategoryService.DoesCategoryExists(categoryToAppend);

            if (categoryExists)
            {
                throw new CustomValidationException(new List<string> { "Category already exists!" });

            }

            var result = await _restaurantCategoryService.AddCategoryAsync(categoryToAppend);
            return result;

        }
    }
}