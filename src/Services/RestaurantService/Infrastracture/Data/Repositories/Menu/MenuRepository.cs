using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Menu;
using Domain.Repositories.Menu;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data.Repositories.Menu
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantServiceDbContext _context;

        public MenuRepository(RestaurantServiceDbContext context)
        {
            _context = context;

        }


        public async Task<bool> AddMenu(AddMenuRequestDto requestDto)
        {
            var menu = new Domain.Entities.Menu
            {
                RestaurantId = requestDto.RestaurantId,
                Name = requestDto.Name,
                Description = requestDto.Description,
                Price = requestDto.Price,
                Image = requestDto.Image
            };

            await _context.AddAsync(menu);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<Domain.Entities.Menu> GetMenuById(int Id)
        {

            var menu = await _context.Menus.FindAsync(Id);
            return menu;

        }

        public async Task<bool> UpdateMenu(int Id, updateMenuRequestDto requestDto)
        {
            var menuToUpdate = await GetMenuById(Id);
            if (menuToUpdate == null)
            {
                return false;

            }

            menuToUpdate.Name = requestDto.Name;
            menuToUpdate.Description = requestDto.Image;
            menuToUpdate.Price = requestDto.Price;

            _context.Entry(menuToUpdate).State = EntityState.Modified;
            var rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;


        }


    }
}