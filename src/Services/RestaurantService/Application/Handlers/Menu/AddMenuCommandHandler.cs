using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Menu;
using Application.Interfaces.Menu;
using Authentication.API.Exceptions;
using Domain.Models.Menu;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Menu
{
    public class AddMenuCommandHandler : IRequestHandler<AddMenuCommand, bool>
    {
        private readonly IMenuService _menuService;
        private readonly IValidator<AddMenuCommand> _validator;

        public AddMenuCommandHandler(IMenuService menuService, IValidator<AddMenuCommand> validator)
        {
            _menuService = menuService;
            _validator = validator;
        }



        public async Task<bool> Handle(AddMenuCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }



            var menu = new AddMenuRequestDto
            {
                RestaurantId = request.RestaurantId,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Image = request.Image

            };

            var result = await _menuService.AddMenuAsync(menu);
            return result;
        }
    }
}