using Feedback.Database.Contexts;
using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Feedback.Database.Services
{
    public class ReviewService : IReviewService
    {
        private FeedbackDbContext _context;

        public ReviewService(FeedbackDbContext context)
        {
            _context = context;
        }

        public void CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public List<Review> GetReviews()
        {
            return _context.Reviews.Include(x => x.ReviewRatingType).ToList();
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Find(id);
        }
    }
}
