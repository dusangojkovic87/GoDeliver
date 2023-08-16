using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Restaurants
{
    public class GetAllRestaurantQuery : IRequest<IEnumerable<Domain.Entities.Restaurant>>
    {

    }
}