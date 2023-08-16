using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Review;

namespace Domain.Repositories.Review
{
    public interface IReviewRepository
    {

        Task<bool> AddReviewToRestaurant(AddReviewRequestDto request);



    }
}