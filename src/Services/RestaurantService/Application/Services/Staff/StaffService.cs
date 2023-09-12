using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Staff;
using Domain.Models.Staff;
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

        public async Task<bool> AddStaffMemberAsync(AddStaffMemberRequestDto requestDto)
        {
            var result = await _staffRepository.AddStaffMember(requestDto);
            return result;
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

        public async Task<bool> UpdateStaffMemberAsync(UpdateStaffMemberRequestDto requestDto)
        {
            var result = await _staffRepository.UpdateStaffMember(requestDto);
            return result;
        }
    }
}