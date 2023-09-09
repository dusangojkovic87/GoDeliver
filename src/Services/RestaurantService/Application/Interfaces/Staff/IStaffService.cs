using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces.Staff
{
    public interface IStaffService
    {
        Task<IEnumerable<Domain.Entities.Staff>> GetAllStaffAsync();
        Task<Domain.Entities.Staff> GetStaffMemberAsync(int Id);
    }
}