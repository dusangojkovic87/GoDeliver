using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Staff;
using Application.Interfaces.Staff;
using Authentication.API.Exceptions;
using Domain.Models.Staff;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Staff
{
    public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffMemberCommand, bool>
    {
        private readonly IStaffService _staffService;
        private readonly IValidator<UpdateStaffMemberCommand> _validator;

        public UpdateStaffCommandHandler(IStaffService staffService, IValidator<UpdateStaffMemberCommand> validator)
        {
            _staffService = staffService;
            _validator = validator;
        }



        public async Task<bool> Handle(UpdateStaffMemberCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }




            var updateRequest = new UpdateStaffMemberRequestDto
            {
                memberId = request.memberId,
                Name = request.Name,
                Role = request.Role

            };

            var result = await _staffService.UpdateStaffMemberAsync(updateRequest);
            return result;
        }
    }
}