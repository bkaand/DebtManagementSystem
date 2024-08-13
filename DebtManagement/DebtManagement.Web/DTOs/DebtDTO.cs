using DebtManagement.Web.Entities.Enums;

namespace DebtManagement.Web.DTOs
{
    public class DebtDTO
    {
        public int Id { get; set; } 
        public int DebtId { get; set; }
        public DebtType DebtType { get; set; }
        public string ClientName { get; set; }
        public decimal DebtAmount { get; set; }
        public int Installments { get; set; }
        public int InstallmentsPaid { get; set; } // 5/12 format akjndfksajkasdjfbds
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
