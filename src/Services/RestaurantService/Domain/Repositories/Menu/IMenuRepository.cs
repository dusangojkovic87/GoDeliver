using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Menu;

namespace Domain.Repositories.Menu
{
    public interface IMenuRepository
    {
        Task<bool> AddMenu(AddMenuRequestDto requestDto);
    }
}