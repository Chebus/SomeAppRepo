using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
