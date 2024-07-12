using System;

namespace DebtManagement.Web.Models
{
    public class Debt
    {
        public int DebtId { get; set; }
        public string UserId { get; set; }
        public string DebtType { get; set; }
        public decimal DebtAmount { get; set; }
        public int Installments { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal EarlyClosingAmount { get; set; }
        public decimal InterestRateMonthly { get; set; }
        public decimal InterestRateYearly { get; set; }
        public decimal InsuranceAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
    }
}
