using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Table;
using Domain.Models.Table;
using Domain.Repositories.Table;

namespace Application.Services.Table
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;

        }

        public async Task<bool> AddTableAsync(AddTableToRestaurantRequestDto requestDto)
        {
            var result = await _tableRepository.AddTableToRestaurant(requestDto);
            return result;

        }

        public async Task<bool> DeleteTableAsync(deleteTableRequestDto requestDto)
        {
            var result = await _tableRepository.DeleteTable(requestDto.Id);
            return result;
        }

        public async Task<bool> UpdateTableAsync(updateTableRequestDto requestDto)
        {
            var result = await _tableRepository.UpdateTable(requestDto);
            return result;
        }
    }
}