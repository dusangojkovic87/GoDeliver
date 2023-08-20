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
    public class AddTableCommandHandler : IRequestHandler<AddTableToRestaurantCommand, bool>
    {
        private readonly ITableService _tableService;

        public AddTableCommandHandler(ITableService tableService)
        {
            _tableService = tableService;

        }



        public async Task<bool> Handle(AddTableToRestaurantCommand request, CancellationToken cancellationToken)
        {
            var addTable = new AddTableToRestaurantRequestDto
            {
                RestaurantId = request.RestaurantId,
                TableNumber = request.TableNumber,
                SeatingCapacity = request.SeatingCapacity

            };

            var result = await _tableService.AddTableAsync(addTable);
            return result;

        }
    }
}