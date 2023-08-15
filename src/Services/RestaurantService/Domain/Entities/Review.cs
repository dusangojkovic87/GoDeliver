using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Comment { get; set; }
        [Required]
        public DateTime DatePosted { get; set; }


    }
}