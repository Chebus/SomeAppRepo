using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.Database.Models
{
    [Table("users")]
    public class User
    {
        [Column("id"), Key]
        public string Id { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }
    }
}
