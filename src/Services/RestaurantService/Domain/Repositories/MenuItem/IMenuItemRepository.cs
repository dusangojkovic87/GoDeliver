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
    }
}