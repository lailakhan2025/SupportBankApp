

namespace SupportBank
{
    class PrintOutput
    {
        public static void PrintAllAccountBalance(HandleTransactions handletransactions)
        {
            var accounts = handletransactions.GetAllAccounts();
            Console.WriteLine($"\n===Support Bank Account Register===");

            Console.WriteLine($"\n{"Name",-15} {"Payable",-10} {"Receivable",-10}");
            Console.WriteLine(new string('-', 50));

            foreach (var account in accounts.Values)
            {
                Console.WriteLine($"{account.Name,-15} £{account.TotalPayable,-10} £{account.TotalReceivable,-10}");
            }

            Console.WriteLine($"{new string('-', 50)}\n");

        }
        public static void PrintAllAccountTransactions(HandleTransactions handletransactions)
        {
            var accounts = handletransactions.GetAllAccounts();
            Console.WriteLine($"Support Bank Account Register");

            foreach (var account in accounts.Values)
            {
                Console.WriteLine($"\n=== Account Transactions for {account.Name} ===\n");

                Console.WriteLine($"{"Date",-12} {"Name",-10} {"Amount",-8} {"Narrative"}");
                Console.WriteLine(new string('-', 60));

                List<Transaction> payables = account.payables;
                Console.WriteLine("\nPayables: ");
                foreach (var transactionitem in payables)
                {
                    Console.WriteLine($"{transactionitem.Date.ToShortDateString(),-12} {transactionitem.From,-10} " +
                    $" £{transactionitem.Amount,-8} {transactionitem.Narrative}");
                }

                List<Transaction> receivables = account.receivables;
                Console.WriteLine("\nReceivables: ");
                foreach (var transactionitem in receivables)
                {
                    Console.WriteLine($"{transactionitem.Date.ToShortDateString(),-12} {transactionitem.To,-10} " +
                    $" £{transactionitem.Amount,-8} {transactionitem.Narrative}");
                }

                Console.WriteLine(new string('-', 60));
                Console.WriteLine($"Total Payable:  £{account.TotalPayable} | Total Receivable: £{account.TotalReceivable}\n");
            }
        }
    }
}