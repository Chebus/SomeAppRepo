using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Database.Contexts
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
