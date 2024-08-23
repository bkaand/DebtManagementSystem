using System.Collections.Generic;

namespace DebtManagement.Web.DTOs
{
    public class CalculatorViewModel
    {
        public decimal TotalDebts { get; set; }
        public decimal TotalIncomes { get; set; }
        public decimal ThisMonthInstallments { get; set; }
        public string ClientId { get; set; }  
        public List<string> IncomeLabels { get; set; }
        public List<decimal> IncomeValues { get; set; }
        public List<string> DebtLabels { get; set; }
        public List<decimal> DebtValues { get; set; }
        public List<string> PaymentLabels { get; set; }
        public List<decimal> PaymentValues { get; set; }

        // Fields for monthly debt vs. income comparison
        public List<string> MonthLabels { get; set; }  
        public List<decimal> MonthlyDebtValues { get; set; }  
        public List<decimal> MonthlyIncomeValues { get; set; }  

        public CalculatorViewModel()
        {
            IncomeLabels = new List<string>();
            IncomeValues = new List<decimal>();
            DebtLabels = new List<string>();
            DebtValues = new List<decimal>();
            PaymentLabels = new List<string>();
            PaymentValues = new List<decimal>();

            // Initialize monthly comparison fields
            MonthLabels = new List<string>();
            MonthlyDebtValues = new List<decimal>();
            MonthlyIncomeValues = new List<decimal>();
        }
    }
}
