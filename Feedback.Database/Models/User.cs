﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback.Database.Models
{
    [Table("users")]
    public class User
    {
        [Column("user_id"), Key]
        public string UserId { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }
    }
}
