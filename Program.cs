// See https://aka.ms/new-console-template for more information
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    class SupportBank
    {
        public static void Main()
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Users\LaiKha\Training\SupportBankApp\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
            
            AccountHandler accounthandler = new AccountHandler();
            List<Transaction> transactions = new List<Transaction>();

            string filepath = "DodgyTransactions2015.csv";
            FileReader.ReadFile(filepath, transactions);
            accounthandler.LoadAccountTransactions(transactions);

            while (true)
            {
                Console.WriteLine("Enter the index number of the option you would like to choose:\n");
                Console.WriteLine("1. List all account balance\n");
                Console.WriteLine("2. Select an account to list transactions\n");
                Console.WriteLine("3. Exit");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        Printer.PrintAllAccountBalance(accounthandler);
                        break;
                    case "2":
                        var selectedaccount = accounthandler.GetSelectedAccount();
                        if (selectedaccount == null)
                            continue;
                        Printer.PrintSelectedAccountTransactions(selectedaccount);
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again");
                        break;
                }
            }
        }
    }
}

