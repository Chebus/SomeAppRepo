using Feedback.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Database.Interfaces
{
    public interface ILookupService
    {
        List<ReviewRatingType> GetReviewRatingTypes();
    }
}
