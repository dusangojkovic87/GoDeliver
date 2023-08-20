using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Table
{
    public class updateTableRequestDto
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }

        public string TableNumber { get; set; }

        public int SeatingCapacity { get; set; }

    }
}