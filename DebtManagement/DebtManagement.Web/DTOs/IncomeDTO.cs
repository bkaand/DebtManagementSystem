namespace DebtManagement.Web.DTOs
{
    public class IncomeDto
    {
        public int Id { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string AdditionalIncomeSources { get; set; }
        public DateTime RecordedDate { get; set; }
        public int ClientId { get; set; }
    }
}
