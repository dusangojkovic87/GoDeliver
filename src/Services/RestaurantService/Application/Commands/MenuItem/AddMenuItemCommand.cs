using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Commands.MenuItem
{
    public class AddMenuItemCommand : IRequest<bool>
    {
        public int MenuId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }

    }
}