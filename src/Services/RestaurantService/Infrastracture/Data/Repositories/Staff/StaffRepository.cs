using System.Data.Common;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories.Staff;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data.Repositories.Staff
{
    public class StaffRepository : IStaffRepository
    {
        public RestaurantServiceDbContext _context;
        public StaffRepository(RestaurantServiceDbContext context)
        {
            _context = context;

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