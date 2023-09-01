using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Menu;
using Application.Commands.MenuItem;
using Application.Interfaces.MenuItem;
using Domain.Models.MenuItem;
using MediatR;

namespace Application.Handlers.MenuItem
{
    public class AddMenuItemCommandHandler : IRequestHandler<AddMenuItemCommand, bool>
    {
        private readonly IMenuItemService _menuItemService;

        public AddMenuItemCommandHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;

        }


        public async Task<bool> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
        {
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