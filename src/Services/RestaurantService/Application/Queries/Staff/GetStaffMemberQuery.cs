using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Queries.Staff
{
    public class GetStaffMemberQuery : IRequest<Domain.Entities.Staff>
    {
        public int Id { get; set; }

    }
}