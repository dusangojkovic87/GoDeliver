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
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, bool>
    {
        private readonly IMenuService _menuService;
        private readonly IValidator<UpdateMenuCommand> _validator;

        public UpdateMenuCommandHandler(IMenuService menuService, IValidator<UpdateMenuCommand> validator)
        {
            _menuService = menuService;
            _validator = validator;
        }



        public async Task<bool> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }

            var updateRequest = new updateMenuRequestDto
            {
                Name = request.Name,
                Description = request.Name,
                Price = request.Price,
                Image = request.Image

            };

            var result = await _menuService.UpdateMenu(request.Id, updateRequest);
            return result;
        }
    }
}