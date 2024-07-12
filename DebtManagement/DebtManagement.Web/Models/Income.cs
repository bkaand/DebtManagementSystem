using System;

namespace DebtManagement.Web.Models
{
    public class Income
    {
        public int IncomeId { get; set; }
        public string UserId { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string AdditionalIncomeSources { get; set; }
        public DateTime RecordedDate { get; set; }
        public User User { get; set; }
    }
}
