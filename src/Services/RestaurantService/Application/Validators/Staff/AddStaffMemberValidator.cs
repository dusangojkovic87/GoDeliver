using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Staff;
using FluentValidation;

namespace Application.Validators.Staff
{
    public class AddStaffMemberValidator : AbstractValidator<AddStaffMemberCommand>
    {
        public AddStaffMemberValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Name cannot be empty!");
            RuleFor(s => s.Role).NotEmpty().WithMessage("Role cannot be empty!");
            RuleFor(s => s.RestaurantId).NotEmpty().WithMessage("restaurant id field not passed");
            //    RuleFor(s => s.RestaurantId).LessThan(0).WithMessage("Restaurant id not valid");
        }

    }
}