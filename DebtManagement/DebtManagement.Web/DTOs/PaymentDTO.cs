namespace DebtManagement.Web.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int DebtId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal DebtAmount { get; set; }
    }
}
