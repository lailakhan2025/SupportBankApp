using System.Diagnostics.CodeAnalysis;

namespace SupportBank
{
    class Account
    {
        public string Name { get; }
        public int TotalAmountPayable { get; private set; }
        public int TotalAmountReceivable { get; private set; }
        private List<Transaction> Payables { get; } = new();
        private List<Transaction> Receivables { get; } = new();
        public Account(string name, int totalamountpayable, int totalamountreceivable)
        {
            Name = name;
            TotalAmountPayable = totalamountpayable;
            TotalAmountReceivable = totalamountreceivable;
        }

        public void AddPayable(Transaction transaction)
        {
            Payables.Add(transaction);
        }

        public void AddReceivable(Transaction transaction)
        {
            Receivables.Add(transaction);
        }

        public void SetTotalPayable()
        {
            int sum = 0;
            foreach (var transactionitem in Payables)
            {
                sum += transactionitem.Amount;

            }
            TotalAmountPayable = sum;
        }

        public void SetTotalReceivable()
        {
            int sum = 0;
            foreach (var transactionitem in Receivables)
            {
                sum += transactionitem.Amount;

            }
            TotalAmountReceivable = sum;
        }
        
        public void DisplayPayableTransactions()
        {
            Console.WriteLine("\n Payable Transactions: ");
            foreach (var transactionitem in Payables)
            {
                Console.WriteLine($"{transactionitem.Date}, From: {transactionitem.From}, " +
                $"  Amount: {transactionitem.Amount}p, {transactionitem.Narrative}");
            }
        }

        public void DisplayReceivableTransactions()
        {
            Console.WriteLine("\n Receivable Transactions: ");
            foreach (var transactionitem in Receivables)
            {
                Console.WriteLine($"{transactionitem.Date}, From: {transactionitem.From}, " +
                $"  Amount: {transactionitem.Amount}p, {transactionitem.Narrative}");
            }
        }

    }
}