using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Menu;
using Domain.Models.Menu;
using Domain.Repositories.Menu;

namespace Application.Services.Menu
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<bool> AddMenuAsync(AddMenuRequestDto requestDto)
        {

            var result = await _menuRepository.AddMenu(requestDto);

            return result;
        }

        public async Task<bool> DeleteMenuAsync(int Id)
        {
            var result = await _menuRepository.DeleteMenu(Id);
            return result;
        }

        public async Task<bool> UpdateMenu(int Id, updateMenuRequestDto requestDto)
        {
            var result = await _menuRepository.UpdateMenu(Id, requestDto);
            return result;
        }
    }
}