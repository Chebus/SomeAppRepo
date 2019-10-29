using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedback.Web.Models
{
    public class UserViewModel
    {
        [DisplayName("User Id")]
        [Required(ErrorMessage = "User Id field is required.")]
        public string Id { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set; }
    }
}
