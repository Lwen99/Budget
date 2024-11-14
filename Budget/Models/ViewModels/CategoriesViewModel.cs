using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Budget.Models.ViewModels
{
    public class CategoriesViewModel
    {
        public int SelectedCategoryId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoriesDropDown { get; set; }


    }
}
