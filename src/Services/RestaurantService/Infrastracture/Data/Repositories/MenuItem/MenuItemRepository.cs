using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.MenuItem;
using Domain.Repositories.MenuItem;

namespace Infrastracture.Data.Repositories.MenuItem
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantServiceDbContext _context;
        public MenuItemRepository(RestaurantServiceDbContext context)
        {
            _context = context;

        }


        public async Task<bool> AddMenuItem(AddMenuItemRequestDto requestDto)
        {

            var newMenuItem = new Domain.Entities.MenuItem
            {
                Name = requestDto.Name,
                Description = requestDto.Description,
                Price = requestDto.Price,
                Image = requestDto.Image,
                CategoryId = requestDto.CategoryId,
                MenuId = requestDto.MenuId
            };

            var categoryExists = await _context.Categories.FindAsync(requestDto.CategoryId);
            var menuExists = await _context.Menus.FindAsync(requestDto.MenuId);

            if (categoryExists == null || menuExists == null)
            {
                return false;

            }

            await _context.AddAsync(newMenuItem);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;

        }

        public async Task<bool> DeleteMenuItem(DeleteMenuItemRequestDto requestDto)
        {
            var menuItemFromDb = await _context.MenuItems.FindAsync(requestDto.Id);
            if (menuItemFromDb == null)
            {
                return false;
            }


            _context.Remove(menuItemFromDb);
            var affectedRows = await _context.SaveChangesAsync();

            return affectedRows > 0;
        }

        public async Task<bool> UpdateMenuItem(UpdateMenuItemRequestDto requestDto)
        {
            var menuItemToUpdate = await _context.MenuItems.FindAsync(requestDto.Id);
            if (menuItemToUpdate == null)
            {
                return false;

            }

            menuItemToUpdate.Name = requestDto.Name;
            menuItemToUpdate.Description = requestDto.Description;
            menuItemToUpdate.Price = requestDto.Price;
            menuItemToUpdate.Image = requestDto.Image;

            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;

        }
    }
}