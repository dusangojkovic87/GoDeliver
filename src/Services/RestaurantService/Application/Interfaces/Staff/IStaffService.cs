using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Staff;

namespace Application.Interfaces.Staff
{
    public interface IStaffService
    {
        Task<IEnumerable<Domain.Entities.Staff>> GetAllStaffAsync();
        Task<Domain.Entities.Staff> GetStaffMemberAsync(int Id);
        Task<bool> AddStaffMemberAsync(AddStaffMemberRequestDto requestDto);
        Task<bool> UpdateStaffMemberAsync(UpdateStaffMemberRequestDto requestDto);
    }
}