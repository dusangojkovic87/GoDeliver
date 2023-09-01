using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.MenuItem
{
    public class UpdateMenuItemRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Image { get; set; }


    }
}