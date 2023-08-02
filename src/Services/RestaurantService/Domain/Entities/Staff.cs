using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}