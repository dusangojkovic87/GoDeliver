using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Staff
{
    public class AddStaffMemberRequestDto
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

    }
}