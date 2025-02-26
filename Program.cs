// See https://aka.ms/new-console-template for more information
namespace SupportBank
{
    class SupportBank
    {
        public static void Main(string[] args)
        {
            var accounts = new Dictionary<string, Account>();

            string filepath = "Transactions2014.csv";
            FetchFile.ReadandParseFile(accounts, filepath);
            PrintOutput.PrintAccountBalance(accounts);
        }
    }
}

