
using System.Net;

namespace SupportBank
{
    class AccountHandler
    {
        private Dictionary<string, Account> accounts = new Dictionary<string, Account>();
        public void LoadTransactions(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                GetOrCreateAccount(transaction.From).AddReceivable(transaction);
                GetOrCreateAccount(transaction.To).AddPayable(transaction);
            }

        }
        private Account GetOrCreateAccount(string name)
        {
            if (!accounts.ContainsKey(name))
            {
                accounts[name] = new Account(name);
            }
            return accounts[name];
        }
        private Dictionary<string, Account> SortAccounts()
        {
            return accounts.OrderBy(entry => entry.Key).ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public Dictionary<string, Account> GetAllAccounts()
        {
            return SortAccounts();

        }

        public Account? GetSelectedAccount()
        {
            Console.WriteLine("Enter account name:");
            string selectedaccount = Console.ReadLine();

            if (!accounts.ContainsKey(selectedaccount))
            {
                Console.WriteLine($"There is no account with the name '{selectedaccount}'");
                Console.WriteLine("\nWould you like to search for another account? (Y/N)\n");

                string userinput = Console.ReadLine()?.ToUpper();
                if (userinput == "Y")
                {
                    return GetSelectedAccount();
                }
                else if (userinput == "N")
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again");
                    return GetSelectedAccount();
                }
            }
            else
            {
                return accounts[selectedaccount];
            }
        }
    }
}
















