using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Review;
using Domain.Models.Review;
using Domain.Repositories.Review;

namespace Application.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;


        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;

        }


        public async Task<bool> AddReviewAsync(AddReviewRequestDto request)
        {
            var result = await _reviewRepository.AddReviewToRestaurant(request);
            return result;
        }
    }
}