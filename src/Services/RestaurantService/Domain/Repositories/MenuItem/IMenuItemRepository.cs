using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.MenuItem;

namespace Domain.Repositories.MenuItem
{
    public interface IMenuItemRepository
    {
        Task<bool> AddMenuItem(AddMenuItemRequestDto requestDto);
        Task<bool> DeleteMenuItem(DeleteMenuItemRequestDto requestDto);
        Task<bool> UpdateMenuItem(UpdateMenuItemRequestDto requestDto);
        Task<IEnumerable<Domain.Entities.MenuItem>> GetAllMenuItems();
    }
}