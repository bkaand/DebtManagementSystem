namespace DebtManagement.Web.Entities
{
    public class Client : BaseEntity
    {
        public string ClientName { get; set; }

        // Navigation properties
        public ICollection<Debt> Debts { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
