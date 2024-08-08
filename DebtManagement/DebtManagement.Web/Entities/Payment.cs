using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/*
namespace DebtManagement.Web.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        public int DebtId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPaid { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [ForeignKey("DebtId")]
        public Debt Debt { get; set; }
    }
}
*/
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
