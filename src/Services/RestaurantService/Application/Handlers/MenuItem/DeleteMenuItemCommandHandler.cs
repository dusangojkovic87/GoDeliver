using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.MenuItem;
using Application.Interfaces.MenuItem;
using Domain.Models.MenuItem;
using MediatR;

namespace Application.Handlers.MenuItem
{

    public class DeleteMenuItemCommandHandler : IRequestHandler<DeleteMenuItemCommand, bool>
    {
        private readonly IMenuItemService _menuItemService;
        public DeleteMenuItemCommandHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;

        }


        public async Task<bool> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {

            var deleteMenuItem = new DeleteMenuItemRequestDto
            {
                Id = request.Id

            };

            var result = await _menuItemService.DeleteMenuItemAsync(deleteMenuItem);
            return result;

        }
    }
}