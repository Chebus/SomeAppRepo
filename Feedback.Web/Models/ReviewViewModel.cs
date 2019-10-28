using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedback.Web.Models
{
    public class ReviewViewModel
    {
        [DisplayName("Rating")]
        public string Rating { get; set; }

        [DisplayName("Comment")]
        [Required(ErrorMessage = "Comment field is required.")]
        public string Comment { get; set; }
    }
}
