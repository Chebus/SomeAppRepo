using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedback.Web.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        [DisplayName("Rating")]
        [Required(ErrorMessage = "Rating field is required.")]
        public int RatingId { get; set; }

        [DisplayName("Rating")]
        public string Rating { get; set; }

        [DisplayName("Comment")]
        [Required(ErrorMessage = "Comment field is required.")]
        public string Comment { get; set; }

        public SelectList RatingTypes { get; set; }
    }
}
