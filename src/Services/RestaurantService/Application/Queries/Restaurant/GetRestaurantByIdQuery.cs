using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Restaurant
{
    public class GetRestaurantByIdQuery : IRequest<Domain.Entities.Restaurant>
    {
        public int Id { get; set; }

    }
}