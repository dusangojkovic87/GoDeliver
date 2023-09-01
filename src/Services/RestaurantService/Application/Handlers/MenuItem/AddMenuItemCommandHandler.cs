using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Menu;
using Application.Commands.MenuItem;
using Application.Interfaces.MenuItem;
using Authentication.API.Exceptions;
using Domain.Models.MenuItem;
using FluentValidation;
using MediatR;

namespace Application.Handlers.MenuItem
{
    public class AddMenuItemCommandHandler : IRequestHandler<AddMenuItemCommand, bool>
    {
        private readonly IMenuItemService _menuItemService;
        private readonly IValidator<AddMenuItemCommand> _validator;

        public AddMenuItemCommandHandler(IMenuItemService menuItemService, IValidator<AddMenuItemCommand> validator)
        {
            _validator = validator;
            _menuItemService = menuItemService;

        }


        public async Task<bool> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }




            var newMenuItem = new AddMenuItemRequestDto
            {
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                CategoryId = request.CategoryId,
                MenuId = request.MenuId,
                Price = request.Price

            };





            var result = await _menuItemService.AddMenuItemAsync(newMenuItem);
            return result;


        }
    }
}