using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        public string TableNumber { get; set; }
        [Required]
        public int SeatingCapacity { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}