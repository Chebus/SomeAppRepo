using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using System.Collections.Generic;

namespace Feedback.Database.Services
{
    public class LookupService : ILookupService
    {
        public List<ReviewRatingType> GetReviewRatingTypes()
        {
            //todo
            return new List<ReviewRatingType>()
            {
                new ReviewRatingType()
                {
                    Id = 1,
                    EnglishText = "Excellent"
                }
            };
        }
    }
}
