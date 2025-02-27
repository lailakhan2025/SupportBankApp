
namespace SupportBank
{
    class HandleTransactions
    {
        private List<Transaction> transactions = new List<Transaction>();
        private Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        public void AddTransactions(DateOnly date, string from, string to, string narrative, int amount)
        {
            Transaction transaction = new Transaction(date, from, to, narrative, amount);
            transactions.Add(transaction);

            SetAccount(from).AddReceivable(transaction);
            SetAccount(to).AddPayable(transaction);

        }

        private Account SetAccount(string name)
        {
            if (!accounts.ContainsKey(name))
            {
                accounts[name] = new Account(name);
            }
            return accounts[name];
        }

        public Account GetSelectedAccount(string name)
        {
            return accounts.ContainsKey(name) ? accounts[name] : null;
        }
        
        private Dictionary<string,Account> SortAccounts()
        {
            return accounts.OrderBy(entry=>entry.Key).ToDictionary( entry=>entry.Key,entry=>entry.Value);
        }
        public Dictionary<string,Account> GetAllAccounts()
        {
            return SortAccounts();

        }












    }


}