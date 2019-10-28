using Feedback.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Database.Interfaces
{
    public interface IReviewService
    {
        void CreateReview(Review review);

        Review GetReview(int id);

        List<Review> GetReviews();
    }
}
