using Feedback.Database.Models;
using Feedback.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Services
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
