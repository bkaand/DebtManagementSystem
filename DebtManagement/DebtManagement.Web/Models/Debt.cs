
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using DebtManagement.Web.Models; // Add this using directive

namespace DebtManagement.Web.Models
{
    public class Debt
    {
        [Key]
        public int DebtId { get; set; }

        [Required]
        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public User Client { get; set; }

        public string DebtType { get; set; }

        [Required]
        public decimal DebtAmount { get; set; }

        public int Installments { get; set; }

        public decimal RemainingAmount { get; set; }

        public decimal EarlyClosingAmount { get; set; }

        public decimal InterestRateMonthly { get; set; }

        public decimal InterestRateYearly { get; set; }

        public decimal InsuranceAmount { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
