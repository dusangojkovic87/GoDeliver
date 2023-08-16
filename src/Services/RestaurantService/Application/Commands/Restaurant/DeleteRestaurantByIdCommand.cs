using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Restaurant
{
    public class DeleteRestaurantByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }

    }
}