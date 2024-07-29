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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DebtManagement.Web.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string ClientName { get; set; }

        public ICollection<Debt> Debts { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}

