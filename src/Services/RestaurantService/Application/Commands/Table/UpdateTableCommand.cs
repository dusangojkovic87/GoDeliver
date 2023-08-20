using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Table
{
    public class UpdateTableCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }

        public string TableNumber { get; set; }

        public int SeatingCapacity { get; set; }

    }
}