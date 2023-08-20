using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        [Required]
        public DateTime ReservationTime { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [ForeignKey("TableId")]
        public Table Table { get; set; }
    }
}