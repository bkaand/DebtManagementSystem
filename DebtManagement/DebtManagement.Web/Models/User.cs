/*using Microsoft.AspNetCore.Identity;
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
*/

using Microsoft.AspNetCore.Identity;
using System;

namespace DebtManagement.Web.Models
{
    public class User : IdentityUser
    {
        // Additional properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
