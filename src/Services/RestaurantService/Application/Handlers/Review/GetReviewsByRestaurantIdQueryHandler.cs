using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.Review;
using Application.Queries.Review;
using Domain.Models.Review;
using MediatR;

namespace Application.Handlers.Review
{
    public class GetReviewsByRestaurantIdQueryHandler : IRequestHandler<GetReviewsByRestaurantIdQuery, IEnumerable<Domain.Entities.Review>>
    {
        private readonly IReviewService _reviewService;

        public GetReviewsByRestaurantIdQueryHandler(IReviewService reviewService)
        {
            _reviewService = reviewService;

        }



        public async Task<IEnumerable<Domain.Entities.Review>> Handle(GetReviewsByRestaurantIdQuery request, CancellationToken cancellationToken)
        {

            var reviewsRequest = new GetReviewsByRestaurantIdRequestDto
            {
                restaurantId = request.Id

            };

            var result = await _reviewService.GetReviewsByRestaurantAsync(reviewsRequest);

            return result;
        }
    }
}