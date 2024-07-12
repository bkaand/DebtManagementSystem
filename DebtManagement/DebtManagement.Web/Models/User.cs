using Microsoft.AspNetCore.Identity;
using System;

namespace DebtManagement.Web.Models
{
    public class User : IdentityUser
    {
        public string ClientName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
