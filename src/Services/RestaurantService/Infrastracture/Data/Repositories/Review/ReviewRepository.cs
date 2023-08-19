using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Review;
using Domain.Repositories.Review;

namespace Infrastracture.Data.Repositories.Review
{
    public class ReviewRepository : IReviewRepository
    {

        private readonly RestaurantServiceDbContext _context;

        public ReviewRepository(RestaurantServiceDbContext context)
        {
            _context = context;

        }


        public async Task<bool> AddReviewToRestaurant(AddReviewRequestDto request)
        {

            var restaurant = await _context.Restaurants.FindAsync(request.RestaurantId);

            if (restaurant == null)
            {
                throw new InvalidOperationException("Restaurant not found!");
            }

            var reviewToAdd = new Domain.Entities.Review
            {
                RestaurantId = request.RestaurantId,
                UserName = request.UserName,
                Comment = request.Comment,
                DatePosted = request.DatePosted,
                Rating = request.Rating


            };

            _context.Reviews.Add(reviewToAdd);
            var result = await _context.SaveChangesAsync();

            return result > 0;

        }

        public async Task<bool> DeleteReview(deleteReviewRequestDto request)
        {

            var reviewToDelete = await _context.Reviews.FindAsync(request.Id);
            if (reviewToDelete == null)
            {
                return false;

            }

            _context.Reviews.Remove(reviewToDelete);
            var result = _context.SaveChanges() > 0;

            return result;
        }
    }
}