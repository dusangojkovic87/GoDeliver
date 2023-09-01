using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.MenuItem;

namespace Application.Interfaces.MenuItem
{
    public interface IMenuItemService
    {
        Task<bool> AddMenuItemAsync(AddMenuItemRequestDto requestDto);
        Task<bool> DeleteMenuItemAsync(DeleteMenuItemRequestDto requestDto);
        Task<bool> UpdateMenuItem(UpdateMenuItemRequestDto requestDto);
    }
}