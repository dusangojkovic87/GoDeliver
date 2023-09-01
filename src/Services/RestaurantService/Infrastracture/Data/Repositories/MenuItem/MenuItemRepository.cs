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
    }
}