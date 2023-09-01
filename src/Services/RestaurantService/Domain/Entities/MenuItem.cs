using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public int MenuId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }

        public Menu Menu { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}