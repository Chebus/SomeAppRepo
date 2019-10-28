using System.Collections.Generic;

namespace Feedback.Database.Models
{
    public class ReviewRatingType
    {
        public int Id { get; set; }

        public string EnglishText { get; set; }

        public virtual IEnumerable<Review> Reviews { get; set; }
    }
}
