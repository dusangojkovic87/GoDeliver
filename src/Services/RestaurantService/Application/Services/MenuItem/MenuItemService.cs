using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.MenuItem;
using Authentication.API.Exceptions;
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

        public async Task<IEnumerable<Domain.Entities.MenuItem>> GetAllMenuItemsAsync()
        {
            var result = await _menuItemRepository.GetAllMenuItems();
            return result;
        }

        public async Task<Domain.Entities.MenuItem> GetMenuItemByIdAsync(GetMenuItemByIdRequestDto requestDto)
        {

            var result = await _menuItemRepository.GetMenuItemById(requestDto);

            if (result == null)
            {
                throw new CustomValidationException(new List<string> { "Error,item not found" });

            }

            return result;



        }

        public async Task<bool> UpdateMenuItem(UpdateMenuItemRequestDto requestDto)
        {
            var result = await _menuItemRepository.UpdateMenuItem(requestDto);
            return result;
        }
    }
}