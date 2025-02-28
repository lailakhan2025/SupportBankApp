
using NLog;

namespace SupportBank
{
    class FileReader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public static void ReadFile(string filepath, List<Transaction> transactions)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    Logger.Error($"File Not Found: {filepath}");
                    throw new FileLoadException("Error: Transaction file not found");
                }
                string[] lines = File.ReadAllLines(filepath);
                int linenumber = 1;

                foreach (string line in lines.Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] datapoint = line.Split(',');
                    if (datapoint.Length != 5)
                    {
                        Logger.Warn($"Invalid transaction format with " +
                        $"inaccurate column length {datapoint.Length} in line {linenumber})");
                    }
                    if (!DateOnly.TryParse(datapoint[0], out DateOnly date))
                    {
                        Logger.Error($"Invalid date format: {datapoint[0]} in line {linenumber})");
                        throw new FormatException($"Invalid date format: {datapoint[0]} in line {linenumber})");
                    }
                    string from = datapoint[1];
                    string to = datapoint[2];
                    string narrative = datapoint[3];
                    if (!float.TryParse(datapoint[4], out float parsedamount))
                    {
                        Logger.Error($"Invalid amount:{datapoint[4]} in line {linenumber})");
                        throw new FormatException($"Invalid amount:{datapoint[4]} in line {linenumber})");
                    }
                    int amount = Convert.ToInt32(parsedamount);
                    transactions.Add(new Transaction(date, from, to, narrative, amount));
                    linenumber++;
                }
            }
            catch (FileNotFoundException error)
            {
                Logger.Error($"Error:{error}");
                Console.WriteLine($"Error:{error}");
            }
            catch (IOException error)
            {
                Logger.Fatal($"Error Reading file: {error}");
                Console.WriteLine($"Error:{error.Message}");
            }
        }

    }
}
