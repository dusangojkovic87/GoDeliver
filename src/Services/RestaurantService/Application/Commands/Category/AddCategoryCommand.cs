using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class AddCategoryCommand : IRequest<Category>
    {
        [Required]
        public string Name { get; set; }

    }
}