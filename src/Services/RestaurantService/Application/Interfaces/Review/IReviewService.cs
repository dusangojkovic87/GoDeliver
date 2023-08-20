using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Review;

namespace Application.Interfaces.Review
{
    public interface IReviewService
    {
        Task<bool> AddReviewAsync(AddReviewRequestDto request);
        bool DeleteReviewById(deleteReviewRequestDto request);
        Task<bool> UpdateReviewAsync(updateReviewRequestDto request);
        Task<IEnumerable<Domain.Entities.Review>> GetReviewsByRestaurantAsync(GetReviewsByRestaurantIdRequestDto request);
    }
}