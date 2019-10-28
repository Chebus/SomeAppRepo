﻿namespace Feedback.Database.Models
{
    public class Review
    {
        public int ReviewRatingId { get; set; }

        public string Comment { get; set; }

        public virtual ReviewRatingType ReviewRatingType { get; set; }
    }
}