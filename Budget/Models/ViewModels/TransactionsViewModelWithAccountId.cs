namespace Budget.Models.ViewModels
{
    public class TransactionsViewModelWithAccountId
    {
        public int AccountId { get; set; }

        public IEnumerable<Transaction> Transaction { get; set; }
    }
}
