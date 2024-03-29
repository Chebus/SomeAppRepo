﻿using Feedback.Database.Models;
using Feedback.Web.Models;

namespace Feedback.UserInterface.Mappers
{
    public static class ReviewListMapper
    {
        public static ReviewListViewModel ToListVm(this Review entity, string viewLinkUrl)
        {
            return new ReviewListViewModel()
            {
                Rating = entity.ReviewRatingType.EnglishText,
                ViewLink = $"<a href='javascript: void(0);' data-url='{viewLinkUrl}' class='tcModalButton' data-toggle='modal' data-target='#mdlModal' data-title='Review'>View</a>"
            };
        }
    }
}
