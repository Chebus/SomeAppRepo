using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback.Database.Models
{
    [Table("reviews")]
    public class Review
    {
        [Column("review_id"), Key]
        public int Id { get; set; }

        [Column("review_rating_type_id")]
        public int ReviewRatingTypeId { get; set; }

        [Column("comment_txt")]
        public string Comment { get; set; }

        [ForeignKey(nameof(ReviewRatingTypeId))]
        public virtual ReviewRatingType ReviewRatingType { get; set; }
    }
}
