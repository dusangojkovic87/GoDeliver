using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Menu;

namespace Application.Interfaces.Menu
{
    public interface IMenuService
    {
        Task<bool> AddMenuAsync(AddMenuRequestDto requestDto);
        Task<bool> UpdateMenu(int Id, updateMenuRequestDto requestDto);
    }
}