namespace DebtManagement.Web.DTOs
{
    public class DebtDTO
    {
        public int DebtId { get; set; }
        public string DebtType { get; set; }
        public decimal DebtAmount { get; set; }
        public int Installments { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal EarlyClosingAmount { get; set; }
        public decimal InterestRateMonthly { get; set; }
        public decimal InterestRateYearly { get; set; }
        public decimal InsuranceAmount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
