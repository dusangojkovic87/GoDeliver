using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Staff
{
    public class UpdateStaffMemberCommand : IRequest<bool>
    {
        public int memberId { get; set; }
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

    }
}