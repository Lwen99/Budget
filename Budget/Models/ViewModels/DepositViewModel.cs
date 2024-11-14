using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models.ViewModels
{
    public class DepositViewModel
    {
        public int AccountId { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]

        public decimal? Amount { get; set; }
    }
}
