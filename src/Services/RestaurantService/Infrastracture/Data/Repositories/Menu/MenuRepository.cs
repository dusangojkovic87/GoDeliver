using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Menu;
using Domain.Repositories.Menu;

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
    }
}