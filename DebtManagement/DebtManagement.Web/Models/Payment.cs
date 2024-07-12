public class Payment
{
    public int PaymentId { get; set; }
    public int DebtId { get; set; }
    public decimal AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
    public Debt Debt { get; set; }
}
