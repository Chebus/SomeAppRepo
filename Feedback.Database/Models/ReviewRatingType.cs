using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback.Database.Models
{
    [Table("review_rating_types")]
    public class ReviewRatingType
    {
        [Column("review_rating_type_id"), Key]
        public int ReviewRatingTypeId { get; set; }

        [Column("english_name_txt")]
        public string EnglishText { get; set; }
    }
}
