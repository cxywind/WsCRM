using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WsCRM.Models
{
    public class User
    {
        [Column(TypeName = "nvarchar"), StringLength(128)]
        public string UserId { get; set; }

        [Column(TypeName = "nvarchar"), StringLength(256)]
        public string Email { get; set; }

        [Column(TypeName = "bit")]
        public bool EmailConfirmed { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string PasswordHash { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string SecurityStamp { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "bit")]
        public bool PhoneNumberConfirmed { get; set; }

        [Column(TypeName = "bit")]
        public bool TwoFactorEnabled { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LockoutEndDateUtc { get; set; }

        [Column(TypeName = "bit")]
        public bool LockoutEnabled { get; set; }

        [Column(TypeName = "bit")]
        public bool AccessFailedCount { get; set; }

        [Required]
        [Column(TypeName = "nvarchar"), StringLength(256)]
        public string UserName { get; set; }

        [Column(TypeName = "bit")]
        public bool IsComfirmed { get; set; }
    }
}