using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories.Staff
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Domain.Entities.Staff>> GetAllStaff();
        Task<Domain.Entities.Staff> GetStaffMember(int Id);

    }
}