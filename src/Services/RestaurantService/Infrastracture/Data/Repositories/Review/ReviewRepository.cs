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


        public bool CheckIfReviewBelongsToUser(deleteReviewRequestDto requestDto)
        {

            var review = _context.Reviews.FirstOrDefault(r => r.Id == requestDto.Id);
            if (review == null)
            {
                return false;
            }

            if (review.UserName == requestDto.userEmail)
            {
                return true;
            }

            return false;

        }

        public bool DeleteReview(deleteReviewRequestDto request)
        {

            var reviewToDelete = _context.Reviews.Find(request.Id);
            if (reviewToDelete == null)
            {
                return false;

            }

            var doesReviewBelongsToUser = CheckIfReviewBelongsToUser(request);

            if (!doesReviewBelongsToUser)
            {
                return false;
            }



            _context.Reviews.Remove(reviewToDelete);
            var result = _context.SaveChanges() > 0;

            return result;
        }

        public async Task<Domain.Entities.Review> GetReviewByIdAsync(int Id)
        {

            var result = await _context.Reviews.FindAsync(Id);
            return result;
        }

        public Task<IEnumerable<Domain.Entities.Review>> GetReviewsByRestaurant(GetReviewsByRestaurantIdRequestDto requestDto)
        {

            var reviews = _context.Reviews.Where(r => r.RestaurantId == requestDto.restaurantId).ToList();
            return Task.FromResult<IEnumerable<Domain.Entities.Review>>(reviews);
        }

        public async Task<bool> UpdateReview(updateReviewRequestDto requestDto)
        {

            var reviewToUpdate = await GetReviewByIdAsync(requestDto.Id);

            if (reviewToUpdate == null)
            {
                return false;
            }

            reviewToUpdate.Comment = requestDto.Comment;
            reviewToUpdate.Rating = requestDto.Rating;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}