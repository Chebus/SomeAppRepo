using Feedback.Database.Contexts;
using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Feedback.Database.Services
{
    public class LookupService : ILookupService
    {
        private FeedbackDbContext _context;

        public LookupService(FeedbackDbContext context)
        {
            _context = context;
        }

        public List<ReviewRatingType> GetReviewRatingTypes()
        {
            return _context.ReviewRatingTypes.ToList();
        }
    }
}
