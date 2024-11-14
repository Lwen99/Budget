using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models.ViewModels
{
    public class TransactionsViewModel
    {
        public int SelectedCategoryId { get; set; }
        [ValidateNever]
        public CategoriesViewModel Categories { get; set; }

        public TransactionTypes SelectedType { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TransactionTypes { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AccountId { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]

        public decimal? Amount { get; set; }


    }
}
