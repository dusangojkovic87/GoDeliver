using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Table;

namespace Domain.Repositories.Table
{
    public interface ITableRepository
    {
        Task<bool> AddTableToRestaurant(AddTableToRestaurantRequestDto requestDto);
    }
}