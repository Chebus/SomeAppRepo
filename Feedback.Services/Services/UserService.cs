using Feedback.Database.Contexts;
using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using Microsoft.AspNetCore.Identity;

namespace Feedback.Database.Services
{
    public class UserService : IUserService
    {
        private FeedbackDbContext _context;
        private IPasswordHasher<User> _passwordHasher;

        public UserService(FeedbackDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public User Authenticate(string id, string password)
        {
            var user = _context.Users.Find(id);

            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return user;
        }

        public User Create(string id, string password)
        {
            var user = new User() { Id = id };
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
