using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Queries.Staff
{
    public class GetAllStaffQuery : IRequest<IEnumerable<Domain.Entities.Staff>>
    {

    }
}