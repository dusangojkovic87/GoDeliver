using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Table;

namespace Application.Interfaces.Table
{
    public interface ITableService
    {
        Task<bool> AddTableAsync(AddTableToRestaurantRequestDto requestDto);
        Task<bool> UpdateTableAsync(updateTableRequestDto requestDto);
        Task<bool> DeleteTableAsync(deleteTableRequestDto requestDto);
    }
}