using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Models.MenuItem
{
    public class AddMenuItemRequestDto
    {
        public int MenuId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}