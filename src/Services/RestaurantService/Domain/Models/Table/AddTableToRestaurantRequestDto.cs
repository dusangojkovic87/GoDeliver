using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Table
{
    public class AddTableToRestaurantRequestDto
    {
        public int RestaurantId { get; set; }
        public string TableNumber { get; set; }
        public int SeatingCapacity { get; set; }
    }
}