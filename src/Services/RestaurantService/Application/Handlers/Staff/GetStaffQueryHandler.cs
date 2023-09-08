using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Staff;
using Application.Queries.Staff;
using MediatR;

namespace Application.Handlers.Staff
{
    public class GetStaffQueryHandler : IRequestHandler<GetAllStaffQuery, IEnumerable<Domain.Entities.Staff>>
    {
        private readonly IStaffService _staffService;

        public GetStaffQueryHandler(IStaffService staffService)
        {
            _staffService = staffService;
        }


        public async Task<IEnumerable<Domain.Entities.Staff>> Handle(GetAllStaffQuery request, CancellationToken cancellationToken)
        {
            var result = await _staffService.GetAllStaffAsync();
            return result;
        }
    }
}