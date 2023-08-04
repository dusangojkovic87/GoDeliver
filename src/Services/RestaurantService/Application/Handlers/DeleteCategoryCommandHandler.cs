using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IRestaurantCategoryService _restaurantCategoryService;
        public DeleteCategoryCommandHandler(IRestaurantCategoryService restaurantCategoryService)
        {
            _restaurantCategoryService = restaurantCategoryService;

        }


        async Task<bool> IRequestHandler<DeleteCategoryCommand, bool>.Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _restaurantCategoryService.DeleteCategoryByIdAsync(request.Id);
            return isDeleted;
        }
    }
}