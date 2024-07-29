using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtManagement.Web.Models
{
    public class Income
    {
        [Key]
        public int IncomeId { get; set; }

        [Required]
        public decimal MonthlyIncome { get; set; }

        public string AdditionalIncomeSources { get; set; }

        [Required]
        public DateTime RecordedDate { get; set; }

        [Required]
        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public User Client { get; set; }
    }
}
