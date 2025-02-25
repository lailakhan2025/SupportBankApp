// See https://aka.ms/new-console-template for more information
namespace SupportBank
{
    class SupportBank
    {
        public static void Main(string[] args)
        {
            List<Transaction> transactions = new List<Transaction>();
            var readfile = new ReadFile();
            var printoutput = new PrintOutput();

            string filepath = "Transactions2014.csv";
            readfile.FetchFile(transactions, filepath);
            
            printoutput.PrintTransactions(transactions);
        }
    }
}

