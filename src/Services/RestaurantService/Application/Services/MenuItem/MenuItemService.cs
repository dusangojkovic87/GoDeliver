using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.MenuItem;
using Domain.Models.Menu;
using Domain.Models.MenuItem;
using Domain.Repositories.MenuItem;

namespace Application.Services.MenuItem
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;


        }


        public async Task<bool> AddMenuItemAsync(AddMenuItemRequestDto requestDto)
        {

            var result = await _menuItemRepository.AddMenuItem(requestDto);
            return result;
        }

        public Task<bool> DeleteMenuItemAsync(DeleteMenuItemRequestDto requestDto)
        {

            var result = _menuItemRepository.DeleteMenuItem(requestDto);
            return result;
        }
    }
}