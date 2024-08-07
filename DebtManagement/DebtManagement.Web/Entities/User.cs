using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DebtManagement.Web.Entities
{
    public class User : IdentityUser
    {
        public string ClientName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }  
        public ICollection<Debt> Debts { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
