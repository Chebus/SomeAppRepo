using Feedback.Database.Models;
using Feedback.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.UserInterface.Mappers
{
    public static class ReviewViewModelMapper
    {
        public static Review ToReview(this ReviewViewModel model)
        {
            return new Review()
            {
                Id = model.Id,
                ReviewRatingId = model.RatingId,
                Comment = model.Comment,
            };
        }
    }
}
