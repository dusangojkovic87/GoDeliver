using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Queries.Review
{
    public class GetReviewsByRestaurantIdQuery : IRequest<IEnumerable<Domain.Entities.Review>>
    {
        public int Id { get; set; }

    }
}