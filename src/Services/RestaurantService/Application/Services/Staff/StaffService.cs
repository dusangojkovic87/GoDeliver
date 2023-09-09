using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Staff;
using Domain.Repositories.Staff;

namespace Application.Services.Staff
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }


        public async Task<IEnumerable<Domain.Entities.Staff>> GetAllStaffAsync()
        {
            var staff = await _staffRepository.GetAllStaff();
            return staff;

        }

        public async Task<Domain.Entities.Staff> GetStaffMemberAsync(int Id)
        {
            var member = await _staffRepository.GetStaffMember(Id);
            return member;
        }
    }
}