using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.MenuItem;
using Application.Queries.MenuItem;
using MediatR;

namespace Application.Handlers.MenuItem
{
    public class GetAllMenuItemsQueryHandler : IRequestHandler<GetAllMenuItemsQuery, IEnumerable<Domain.Entities.MenuItem>>
    {
        private readonly IMenuItemService _menuItemService;
        public GetAllMenuItemsQueryHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;

        }


        public async Task<IEnumerable<Domain.Entities.MenuItem>> Handle(GetAllMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.GetAllMenuItemsAsync();
            return result;
        }
    }
}