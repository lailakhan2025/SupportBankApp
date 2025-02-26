namespace SupportBank
{
    class PrintOutput
    {
        public static void PrintAccountBalance(Dictionary<string,Account>accounts)
        {   
            foreach(var account in accounts.Values)
            {   
                Console.WriteLine($"\nBalance for Account: {account.Name}");
                account.SetTotalPayable();
                account.SetTotalReceivable();
                Console.WriteLine($"Total Payable: {account.TotalAmountPayable}, Total Receivable: {account.TotalAmountReceivable}"); 
            }
        }
        public static void PrintTransactions(Dictionary<string,Account>accounts)
        {   
            foreach (var account in accounts.Values)
            {   
                Console.WriteLine($"\nTransactions for Account: {account.Name}");
                account.DisplayPayableTransactions();
                account.DisplayReceivableTransactions();
            }
        }
    }
}