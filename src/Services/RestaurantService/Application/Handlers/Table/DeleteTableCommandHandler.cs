using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Table;
using Application.Interfaces.Table;
using Domain.Models.Table;
using MediatR;

namespace Application.Handlers.Table
{
    public class DeleteTableCommandHandler : IRequestHandler<DeleteTableCommand, bool>
    {
        private readonly ITableService _tableService;

        public DeleteTableCommandHandler(ITableService tableService)
        {
            _tableService = tableService;

        }



        public async Task<bool> Handle(DeleteTableCommand request, CancellationToken cancellationToken)
        {

            var requestDto = new deleteTableRequestDto
            {
                Id = request.Id

            };

            var result = await _tableService.DeleteTableAsync(requestDto);
            return result;
        }
    }
}