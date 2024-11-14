using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Display(Name ="Transaction Date")]
        public DateTime CreatedDate { get; set; }

        public string?Description { get; set; }
        [ValidateNever]
        [Display(Name = "Transaction Type")]

        public TransactionTypes Type { get; set; }

        [Column(TypeName = "decimal(18, 2)")]

        public decimal?Amount { get; set; }
        public int AccountId { get; set; }
        public int ?CategoryId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name ="Balance")]
        public decimal EndingBalance { get; set; }

        [ValidateNever]
        public Account Account { get; set; }
        [ValidateNever]
        public Category?Category { get; set; }
    }

    public enum TransactionTypes
    {
        Purchase,
        Deposit
    }
}
