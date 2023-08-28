using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Menu;
using Application.Interfaces.Menu;
using MediatR;

namespace Application.Handlers.Menu
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, bool>
    {
        private readonly IMenuService _menuService;

        public DeleteMenuCommandHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }



        public async Task<bool> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var result = await _menuService.DeleteMenuAsync(request.Id);
            return result;
        }
    }
}