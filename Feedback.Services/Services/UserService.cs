using Feedback.Database.Interfaces;
using Feedback.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Database.Services
{
    public class UserService : IUserService
    {
        public async Task<User> Authenticate(string user, string password)
        {
            //TODO:
            return new User()
            {
                Id = "TEST",
                PasswordHash = "12345"
            };
        }
    }
}
