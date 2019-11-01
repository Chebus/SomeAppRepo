using Feedback.Database.Models;
using System.Collections.Generic;

namespace Feedback.Database.Interfaces
{
    public interface ILookupService
    {
        List<ReviewRatingType> GetReviewRatingTypes();
        ReviewRatingType GetReviewRatingType(int id);
    }
}
