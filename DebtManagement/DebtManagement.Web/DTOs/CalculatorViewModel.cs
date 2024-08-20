using System.Collections.Generic;

namespace DebtManagement.Web.DTOs
{
    public class CalculatorViewModel
    {
        public List<DebtDTO> Debts { get; set; }
        public List<IncomeDto> Incomes { get; set; }
        public List<PaymentDTO> Payments { get; set; }

        public List<string> IncomeLabels { get; set; }
        public List<decimal> IncomeValues { get; set; }
        public List<string> DebtLabels { get; set; }
        public List<decimal> DebtValues { get; set; }
        public List<string> PaymentLabels { get; set; }
        public List<decimal> PaymentValues { get; set; }

        public CalculatorViewModel()
        {
            Debts = new List<DebtDTO>();
            Incomes = new List<IncomeDto>();
            Payments = new List<PaymentDTO>();

            IncomeLabels = new List<string>();
            IncomeValues = new List<decimal>();
            DebtLabels = new List<string>();
            DebtValues = new List<decimal>();
            PaymentLabels = new List<string>();
            PaymentValues = new List<decimal>();
        }
    }
}
