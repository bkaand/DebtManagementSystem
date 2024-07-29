namespace DebtManagement.Web.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        // Navigation properties
        public ICollection<Debt> Debts { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
