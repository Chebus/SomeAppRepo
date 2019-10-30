using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedback.Web.Models
{
    public class UserViewModel
    {
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username field is required.")]
        public string Id { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set; }
    }
}
