using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Staff;
using FluentValidation;

namespace Application.Validators.Staff
{
    public class UpdateStaffMemberValidator : AbstractValidator<UpdateStaffMemberCommand>
    {
        public UpdateStaffMemberValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Name cannot be empty!");
            RuleFor(s => s.Role).NotEmpty().WithMessage("Role cannot be empty!");

        }

    }
}