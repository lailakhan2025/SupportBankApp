namespace SupportBank
{
    class PrintOutput
    {
        public void PrintTransactions(List<Transaction> transactions)
        {
            foreach (Transaction transactionitem in transactions)
            {
                Console.WriteLine($" Date: {transactionitem.Date}, From: {transactionitem.From}, To: {transactionitem.To},"+
                $" Narrative: {transactionitem.Narrative}, Amount: £{transactionitem.Amount}");
            }
        }
    }
}