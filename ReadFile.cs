
namespace SupportBank
{
    class ReadFile
    {
        public void FetchFile(List<Transaction> transactions, string filepath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filepath);

                foreach (string line in lines.Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] datapoint = line.Split(',');

                    DateOnly date = DateOnly.Parse(datapoint[0]);
                    string from = datapoint[1];
                    string to = datapoint[2];
                    string narrative = datapoint[3];
                    float amount = float.Parse(datapoint[4]);

                    transactions.Add(new Transaction(date, from, to, narrative, amount));
                }
            }
            catch
            {
                Console.WriteLine("Error reading file");
            }
        }
    }
}