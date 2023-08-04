using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly IRestaurantCategoryService _restaurantCategoryService;

        public GetAllCategoriesQueryHandler(IRestaurantCategoryService restaurantCategoryService)
        {
            _restaurantCategoryService = restaurantCategoryService;

        }
        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _restaurantCategoryService.GetAllCategoriesAsync();
            return categories;
        }
    }
}