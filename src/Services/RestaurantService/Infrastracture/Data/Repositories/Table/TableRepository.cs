using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Table;
using Domain.Repositories.Table;

namespace Infrastracture.Data.Repositories.Table
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantServiceDbContext _context;

        public TableRepository(RestaurantServiceDbContext context)
        {
            _context = context;


        }



        public async Task<bool> AddTableToRestaurant(AddTableToRestaurantRequestDto requestDto)
        {
            var table = new Domain.Entities.Table
            {
                RestaurantId = requestDto.RestaurantId,
                TableNumber = requestDto.TableNumber,
                SeatingCapacity = requestDto.SeatingCapacity

            };

            _context.Tables.Add(table);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}