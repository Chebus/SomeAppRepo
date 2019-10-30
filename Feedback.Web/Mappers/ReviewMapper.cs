using Feedback.Database.Models;
using Feedback.Web.Models;

namespace Feedback.UserInterface.Mappers
{
    public static partial class ReviewMapper
    {
        public static ReviewDto ToDto(this ReviewViewModel vm)
        {
            return new ReviewDto()
            {
                ReviewRatingTypeId = vm.RatingId,
                Comment = vm.Comment,
            };
        }

        public static ReviewViewModel ToVm(this Review entity)
        {
            return new ReviewViewModel()
            {
                Rating = entity.ReviewRatingType.EnglishText,
                Comment = entity.Comment
            };
        }
    }
}
