using DebtManagement.Web.Entities.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DebtManagement.Web.DTOs
{
    public class DebtDTO
    {
        public int Id { get; set; } 
        public int DebtId { get; set; }
        public DebtType DebtType { get; set; }
        public List<SelectListItem> DebtTypesList { get; set; }
        public string ClientName { get; set; } = default!;// i am not sure if this is necessary or not
        public decimal DebtAmount { get; set; }
        public int Installments { get; set; }
        public int InstallmentsPaid { get; set; } // 5/12 format structure
        public decimal RemainingAmount { get; set; }
        public decimal EarlyClosingAmount { get; set; }
        public decimal InterestRateMonthly { get; set; }
        public decimal InterestRateYearly { get; set; }
        public decimal InsuranceAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ClientId { get; set; }
        public int PaidInstallments { get; set; } 

        public string InstallmentsDisplay => $"{InstallmentsPaid}/{Installments}"; // format structure
    }
}
