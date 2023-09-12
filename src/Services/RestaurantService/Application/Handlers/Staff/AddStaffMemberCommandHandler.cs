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
    public class AddStaffMemberCommandHandler : IRequestHandler<AddStaffMemberCommand, bool>
    {
        private readonly IStaffService _staffService;
        private readonly IValidator<AddStaffMemberCommand> _validator;

        public AddStaffMemberCommandHandler(IStaffService staffService, IValidator<AddStaffMemberCommand> validator)
        {
            _staffService = staffService;
            _validator = validator;
        }


        public async Task<bool> Handle(AddStaffMemberCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }



            var addRequest = new AddStaffMemberRequestDto
            {
                Name = request.Name,
                Role = request.Role,
                RestaurantId = request.RestaurantId

            };


            var result = await _staffService.AddStaffMemberAsync(addRequest);
            return result;
        }
    }
}