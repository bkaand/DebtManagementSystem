using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace DebtManagement.Web.Entities
{
    public class Payment : BaseEntity
    {
        public int DebtId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public Debt Debt { get; set; }
    }
}
