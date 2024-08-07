using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DebtManagement.Web.Entities
{
    public class Debt : BaseEntity
    {
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
        public ICollection<Payment> Payments { get; set; }
    }
}
