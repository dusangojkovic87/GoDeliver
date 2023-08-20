using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Table
{
    public class AddTableToRestaurantCommand : IRequest<bool>
    {
        public int RestaurantId { get; set; }
        public string TableNumber { get; set; }
        public int SeatingCapacity { get; set; }

    }
}