using Feedback.Database.Models;
using Feedback.Web.Models;

namespace Feedback.UserInterface.Mappers
{
    public static class ReviewRatingTypeMapper
    {
        public static IdValueViewModel ToVm(this ReviewRatingType entity)
        {
            return new IdValueViewModel()
            {
                Id = entity.ReviewRatingTypeId,
                Value = entity.EnglishText,
            };
        }
    }
}
