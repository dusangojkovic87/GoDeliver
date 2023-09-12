using System.Data.Common;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories.Staff;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Staff;

namespace Infrastracture.Data.Repositories.Staff
{
    public class StaffRepository : IStaffRepository
    {
        public RestaurantServiceDbContext _context;
        public StaffRepository(RestaurantServiceDbContext context)
        {
            _context = context;

        }

        public async Task<bool> AddStaffMember(AddStaffMemberRequestDto requestDto)
        {
            var staffMember = new Domain.Entities.Staff
            {
                Name = requestDto.Name,
                Role = requestDto.Role,
                RestaurantId = requestDto.RestaurantId

            };


            await _context.AddAsync(staffMember);
            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<IEnumerable<Domain.Entities.Staff>> GetAllStaff()
        {
            var staff = await _context.Staff.ToListAsync();
            return staff;

        }

        public async Task<Domain.Entities.Staff> GetStaffMember(int Id)
        {
            var member = await _context.Staff.FindAsync(Id);
            return member;


        }


    }
}