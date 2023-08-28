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

        public async Task<bool> DeleteTable(int Id)
        {
            var tableToDelete = await GetTableByIdAsync(Id);
            if (tableToDelete == null)
            {
                return false;

            }

            _context.Tables.Remove(tableToDelete);
            var rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<Domain.Entities.Table> GetTableByIdAsync(int Id)
        {
            var result = await _context.Tables.FindAsync(Id);
            return result;
        }

        public async Task<bool> UpdateTable(updateTableRequestDto requestDto)
        {
            var tableToUpdate = await GetTableByIdAsync(requestDto.Id);
            if (tableToUpdate == null)
            {
                return false;

            }

            tableToUpdate.TableNumber = requestDto.TableNumber;
            tableToUpdate.SeatingCapacity = requestDto.SeatingCapacity;

            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;

        }


    }
}