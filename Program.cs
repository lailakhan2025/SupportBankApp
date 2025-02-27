// See https://aka.ms/new-console-template for more information

namespace SupportBank
{
    class SupportBank
    {
        public static void Main()
        {
            HandleTransactions handletransactions = new HandleTransactions();

            string filepath = "Transactions2014.csv";
            FetchFile.ReadFile(filepath,handletransactions);

            PrintOutput.PrintAllAccountBalance(handletransactions);
        }
    }
}

