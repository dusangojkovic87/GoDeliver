using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.MenuItem
{
    public class DeleteMenuItemCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}