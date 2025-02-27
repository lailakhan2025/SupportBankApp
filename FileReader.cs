
using System.Transactions;

namespace SupportBank
{
    class FileReader
    {
        public static void ReadFile(string filepath, List<Transaction> transactions)
        {
            try
            {
                if (!File.Exists(filepath))
                    throw new FileLoadException("Error: Transaction file not found");

                string[] lines = File.ReadAllLines(filepath);
                foreach (string line in lines.Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] datapoint = line.Split(',');

                    DateOnly date = DateOnly.Parse(datapoint[0]);
                    string from = datapoint[1];
                    string to = datapoint[2];
                    string narrative = datapoint[3];
                    int amount = Convert.ToInt32(float.Parse(datapoint[4]));

                    transactions.Add(new Transaction(date, from, to, narrative, amount));
                }
            }
            catch (FileNotFoundException error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
            catch (IOException error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
        }

    }
}
