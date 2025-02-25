// See https://aka.ms/new-console-template for more information
namespace SupportBank
{
    class SupportBank
    {
        public static void Main(string[] args)
        {
            List<Transaction> transactions = new List<Transaction>();
            List<User> users = new List<User>();

            string filepath = "Transactions2014.csv";
            ReadFile.FetchFile(transactions, filepath);
            PrintOutput.PrintTransactions(transactions);

            
        }
    }
}

