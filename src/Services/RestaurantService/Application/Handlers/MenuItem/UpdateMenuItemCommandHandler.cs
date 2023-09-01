using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.MenuItem;
using Application.Interfaces.MenuItem;
using Authentication.API.Exceptions;
using Domain.Models.MenuItem;
using FluentValidation;
using MediatR;

namespace Application.Handlers.MenuItem
{
    public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, bool>
    {
        public IMenuItemService _menuItemService;
        public IValidator<UpdateMenuItemCommand> _validator { get; }

        public UpdateMenuItemCommandHandler(IMenuItemService menuItemService, IValidator<UpdateMenuItemCommand> validator)
        {
            _validator = validator;
            _menuItemService = menuItemService;

        }

        public async Task<bool> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }





            var updateRequest = new UpdateMenuItemRequestDto
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Image = request.Image

            };




            var result = await _menuItemService.UpdateMenuItem(updateRequest);
            return result;



        }
    }
}