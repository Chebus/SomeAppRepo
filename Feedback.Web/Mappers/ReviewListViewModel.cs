using Feedback.Database.Models;
using Feedback.Web.Models;

namespace Feedback.UserInterface.Mappers
{
    public static class ReviewListViewModelMapper
    {
        public static ReviewListViewModel ToListVm(this Review entity)
        {
            return new ReviewListViewModel()
            {
                Rating = entity.ReviewRatingType.EnglishText
            };
        }
    }
}
