using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Table
{
    public class DeleteTableCommand : IRequest<bool>
    {
        public int Id { get; set; }

    }
}