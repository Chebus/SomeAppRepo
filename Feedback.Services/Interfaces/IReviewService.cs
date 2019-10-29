using Feedback.Database.Models;
using System.Collections.Generic;

namespace Feedback.Database.Interfaces
{
    public interface IReviewService
    {
        void CreateReview(Review review);

        Review GetReview(int id);

        List<Review> GetReviews();
    }
}
