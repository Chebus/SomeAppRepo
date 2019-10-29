using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Database.Models
{
    public class User
    {
        public string Id { get; set; }

        public string PasswordHash { get; set; }
    }
}
