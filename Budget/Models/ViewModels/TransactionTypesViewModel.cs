using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Budget.Models.ViewModels
{
    public class TransactionTypesViewModel
    {
        public int AccountId {  get; set; }
        public TransactionTypes SelectedType { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TransactionTypes { get; set; }
    }
}
