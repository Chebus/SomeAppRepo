using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using System.Collections.Generic;

namespace Feedback.Database.Services
{
    public class ReviewService : IReviewService
    {
        public void CreateReview(Review review)
        {
            //todo
        }

        public List<Review> GetReviews()
        {
            //todo
            return new List<Review>();
        }

        public Review GetReview(int id)
        {
            //todo
            if (id == 1)
            {
                return new Review();
            }

            return null;
        }
    }
}
