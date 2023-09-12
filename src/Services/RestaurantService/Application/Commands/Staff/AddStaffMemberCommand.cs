using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Staff
{
    public class AddStaffMemberCommand : IRequest<bool>
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}