using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Interfaces;
using Authentication.API.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {

        private readonly IRestaurantCategoryService _restaurantCategoryService;
        public UpdateCategoryCommandHandler(IRestaurantCategoryService restaurantCategoryService)
        {
            _restaurantCategoryService = restaurantCategoryService;

        }


        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var categoryExist = await _restaurantCategoryService.FindCategoryByIdAsync(request.Id);

            if (!categoryExist)
            {
                throw new CustomValidationException(new List<string> { "Category not found!" });

            }

            var category = new Category
            {
                Name = request.Name
            };

            var result = await _restaurantCategoryService.UpdateCategoryAsync(request.Id, category);
            return result;





        }
    }
}