using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Menu;
using Application.Interfaces.MenuItem;
using Application.Queries.MenuItem;
using Domain.Models.MenuItem;
using MediatR;

namespace Application.Handlers.MenuItem
{
    public class GetMenuItemByIdQueryHandler : IRequestHandler<GetMenuItemByIdQuery, Domain.Entities.MenuItem>
    {
        public IMenuItemService _menuItemService;

        public GetMenuItemByIdQueryHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;

        }


        public async Task<Domain.Entities.MenuItem> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
        {
            var getRequest = new GetMenuItemByIdRequestDto
            {
                Id = request.Id

            };


            var result = await _menuItemService.GetMenuItemByIdAsync(getRequest);
            return result;
        }
    }
}