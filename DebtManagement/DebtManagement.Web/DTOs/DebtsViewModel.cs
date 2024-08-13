namespace DebtManagement.Web.DTOs
{
    public class DebtsViewModel
    {
        public DebtsViewModel() 
        {
            CreditCardDebts = new List<DebtDTO>();
            LoanDebts = new List<DebtDTO>();
            AvansDebts = new List<DebtDTO>();
            OtherDebts = new List<DebtDTO>(); 
            MonthlyRentsDebts=new List<DebtDTO>();
        }

        public List<DebtDTO> CreditCardDebts { get; set; }
        public List<DebtDTO> LoanDebts { get; set; }
        public List<DebtDTO> AvansDebts { get; set; }
         public List<DebtDTO> MonthlyRentsDebts { get; set; }
        public List<DebtDTO> OtherDebts { get; set; }

        public bool IsEmpty { get; set; }
    }
}
