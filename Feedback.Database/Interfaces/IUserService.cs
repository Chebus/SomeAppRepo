using Feedback.Database.Models;

namespace Feedback.Database.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string id, string password);

        User Create(string id, string password);
    }
}
