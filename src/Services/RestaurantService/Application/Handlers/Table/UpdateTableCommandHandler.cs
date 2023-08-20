using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Table;
using Application.Interfaces.Table;
using Authentication.API.Exceptions;
using Domain.Models.Table;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Table
{

    public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand, bool>
    {
        private readonly ITableService _tableService;
        private readonly IValidator<UpdateTableCommand> _validator;

        public UpdateTableCommandHandler(ITableService tableService, IValidator<UpdateTableCommand> validator)
        {
            _tableService = tableService;
            _validator = validator;

        }


        public async Task<bool> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors.Select(e => e.ErrorMessage));

            }




            var updateRequest = new updateTableRequestDto
            {
                Id = request.Id,
                TableNumber = request.TableNumber,
                SeatingCapacity = request.SeatingCapacity


            };






            var result = await _tableService.UpdateTableAsync(updateRequest);

            return result;
        }
    }
}