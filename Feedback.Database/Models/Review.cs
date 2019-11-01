using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback.Database.Models
{
    [Table("reviews")]
    public class Review
    {
        [Column("review_id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Column("review_rating_type_id")]
        [ForeignKey(nameof(ReviewRatingType))]
        public int ReviewRatingTypeId { get; set; }

        [Column("comment_txt")]
        [MaxLength(250)]
        [Required]
        public string Comment { get; set; }

        public virtual ReviewRatingType ReviewRatingType { get; set; }
    }
}
