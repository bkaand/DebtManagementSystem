using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DebtManagement.Web.Entities
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public ICollection<Debt> Debts { get; set; }
    }
}
