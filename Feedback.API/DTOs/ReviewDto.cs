using System.ComponentModel.DataAnnotations;

namespace Feedback.Web.Models
{
    public class ReviewDto
    {
        [Required(ErrorMessage = "Rating field is required.")]
        [Range(1, 3, ErrorMessage = "Rating field is invalid.")]
        public int ReviewRatingTypeId { get; set; }

        [Required(ErrorMessage = "Comment field is required.")]
        [MaxLength(250, ErrorMessage = "Comment field cannot exceed 250 characters.")]
        public string Comment { get; set; }
    }
}
