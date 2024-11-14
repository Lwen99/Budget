using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }
        [ValidateNever]
        public ICollection<Transaction> Transactions { get; set; }
    }
}
