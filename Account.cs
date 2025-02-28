
using System.Collections.Immutable;

namespace SupportBank
{
    class Account
    {
        public string Name { get; }
        private List<Transaction> Payables = new();
        private List<Transaction> Receivables = new();
        public Account(string name)
        {
            Name = name;
        }

        public List<Transaction> payables => Payables.ToList();
        public List<Transaction> receivables => Receivables.ToList();

        public void AddPayable(Transaction transaction)
        {
            Payables.Add(transaction);
        }

        public void AddReceivable(Transaction transaction)
        {
            Receivables.Add(transaction);
        }

        public int TotalPayable => Payables.Sum(transactionitem => transactionitem.Amount);
        public int TotalReceivable => Receivables.Sum(transactionitem => transactionitem.Amount);

    }
}