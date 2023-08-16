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
    }
}