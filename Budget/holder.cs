﻿//@using Budget.Models.ViewModels
//@model TransactionTypesViewModel

//@{
//    ViewData["Title"] = "Create";
//}

//<h1>Create</h1>

//<h4>Transaction</h4>
//<hr />
//<div class="row">
//    <div class="col-md-4">
//           <select id="typeSelect" class="form-select" asp-items="@Model.TransactionTypes">
//               <option disabled selected>-Select Transaction Type-</option>
      
//           </select>
//    </div>
//</div>
//<div id="typeForm"></div>
//<div>
//    <a asp-action="Index">Back to List</a>
//</div>

//<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
//<script>
//    $(document).ready(function () {
//        $('#typeSelect').change(function () {
//            var selectedFormId = $(this).val();
//            var accountId = '@Model.AccountId';
//            if (selectedForm) {
//                $.ajax({
//                    url: '@Url.Action("LoadTransactionForm")',
//                    type: 'GET',
//                    data: { formId: selectedFormId, accountId: accountId },
//                    success: function (data) {
//                        $('#typeForm').html(data);
//                    }
//                });
//            } else {
//                $('#typeForm').empty(); // Clear the partial view if no session is selected
//            }
//        });
    
//    });
//</script>
//@section Scripts {
//    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
//}
//@using Budget.Models.ViewModels
//@model TransactionTypesViewModel

//@{
//    ViewData["Title"] = "Create";
//}

//<h1>Create</h1>

//<h4>Transaction</h4>
//<hr />
//<div class="row">
//    <div class="col-md-4">
//           <select id="typeSelect" class="form-select" asp-items="@Model.TransactionTypes">
//               <option disabled selected>-Select Transaction Type-</option>
      
//           </select>
//    </div>
//</div>
//<div id="typeForm"></div>
//<div>
//    <a asp-action="Index">Back to List</a>
//</div>

//<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
//<script>
//    $(document).ready(function () {
//        $('#typeSelect').change(function () {
//            var selectedFormId = $(this).val();
//            var accountId = '@Model.AccountId';
//            if (selectedForm) {
//                $.ajax({
//                    url: '@Url.Action("LoadTransactionForm")',
//                    type: 'GET',
//                    data: { formId: selectedFormId, accountId: accountId },
//                    success: function (data) {
//                        $('#typeForm').html(data);
//                    }
//                });
//            } else {
//                $('#typeForm').empty(); // Clear the partial view if no session is selected
//            }
//        });
    
//    });
//</script>
//@section Scripts {
//    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
//}