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
    public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, bool>
    {
        public IMenuItemService _menuItemService;

        public UpdateMenuItemCommandHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;

        }

        public async Task<bool> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {
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