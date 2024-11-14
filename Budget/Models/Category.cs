using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Budget.Models
{
    public class Category
    {
        public int Id { get; set; }
        [ValidateNever]
        [Display(Name="Category Type")]
        public string Name { get; set; }
        [ValidateNever]
        public ICollection<Transaction> Transactions { get; set; }
    }
}
