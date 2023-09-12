using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Staff;

namespace Domain.Repositories.Staff
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Domain.Entities.Staff>> GetAllStaff();
        Task<Domain.Entities.Staff> GetStaffMember(int Id);
        Task<bool> AddStaffMember(AddStaffMemberRequestDto requestDto);
        Task<bool> UpdateStaffMember(UpdateStaffMemberRequestDto requestDto);

    }
}