using Feedback.Database.Models;
using Feedback.Web.Models;

namespace Feedback.UserInterface.Mappers
{
    public static class ReviewViewModelMapper
    {
        public static Review ToReview(this ReviewViewModel model)
        {
            return new Review()
            {
                Id = model.Id,
                ReviewRatingTypeId = model.RatingId,
                Comment = model.Comment,
            };
        }
    }
}
