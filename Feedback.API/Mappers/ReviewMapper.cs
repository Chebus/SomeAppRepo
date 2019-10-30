using Feedback.Database.Models;
using Feedback.Web.Models;

namespace Feedback.UserInterface.Mappers
{
    public static partial class ReviewMapper
    {
        public static Review ToEntity(this ReviewDto dto)
        {
            return new Review()
            {
                ReviewRatingTypeId = dto.ReviewRatingTypeId,
                Comment = dto.Comment,
            };
        }
    }
}
