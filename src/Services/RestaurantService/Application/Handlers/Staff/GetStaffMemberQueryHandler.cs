using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Staff;
using Application.Queries.Staff;
using MediatR;
using MediatR.Pipeline;

namespace Application.Handlers.Staff
{
    public class GetStaffMemberQueryHandler : IRequestHandler<GetStaffMemberQuery, Domain.Entities.Staff>
    {
        private readonly IStaffService _staffService;

        public GetStaffMemberQueryHandler(IStaffService staffService)
        {
            _staffService = staffService;
        }



        public async Task<Domain.Entities.Staff> Handle(GetStaffMemberQuery request, CancellationToken cancellationToken)
        {
            var result = await _staffService.GetStaffMemberAsync(request.Id);
            return result;
        }
    }
}