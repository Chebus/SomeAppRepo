using Feedback.Database.Models;
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

        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewRatingType> ReviewRatingTypes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
