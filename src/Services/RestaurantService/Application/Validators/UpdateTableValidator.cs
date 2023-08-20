using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Table;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateTableValidator : AbstractValidator<UpdateTableCommand>
    {
        public UpdateTableValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("table id not passed");
            RuleFor(t => t.TableNumber).NotEmpty().WithMessage("Table number not selected");
            RuleFor(t => t.SeatingCapacity).NotEmpty().WithMessage("Seating capacity not set");


        }

    }
}