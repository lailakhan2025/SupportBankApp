namespace SupportBank
{
    class FetchFile
    {
        public static void ReadandParseFile(Dictionary<string, Account> accounts, string filepath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filepath);

                foreach (string line in lines.Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] datapoint = line.Split(',');

                    DateOnly date = DateOnly.Parse(datapoint[0]);
                    string fromUser = datapoint[1];
                    string toUser = datapoint[2];
                    string narrative = datapoint[3];
                    int amount = Convert.ToInt32(float.Parse(datapoint[4]) * 100);

                    Transaction transaction = new Transaction(date, fromUser, toUser, narrative, amount);
                    if (!accounts.ContainsKey(fromUser))
                    { accounts[fromUser] = new Account(fromUser, 0, 0); }
                    accounts[fromUser].AddReceivable(transaction);

                    if (!accounts.ContainsKey(toUser))
                    { accounts[toUser] = new Account(toUser, 0, 0); }
                    accounts[toUser].AddPayable(transaction);
                }
            }
            catch
            {
                Console.WriteLine("Error reading file");
            }
        }

    }
}
