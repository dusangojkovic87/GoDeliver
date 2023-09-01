using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Queries.MenuItem
{
    public class GetMenuItemByIdQuery : IRequest<Domain.Entities.MenuItem>
    {
        public int Id { get; set; }

    }
}