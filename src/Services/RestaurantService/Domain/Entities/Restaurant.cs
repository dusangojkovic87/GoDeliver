using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Required]
        public DateTime OpeningTime { get; set; }
        [Required]
        public DateTime ClosingTime { get; set; }
        public double Rating { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Table> Tables { get; set; }
        public ICollection<Staff> StaffMembers { get; set; }
        public ICollection<PaymentMethod> AcceptedPaymentMethods { get; set; }
    }
}