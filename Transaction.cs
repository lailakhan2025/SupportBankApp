namespace SupportBank
{
    class Transaction
    {
        public DateOnly Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Narrative { get; set; }
        public float Amount { get; set; }

        public Transaction(DateOnly date, string from, string to, string narrative, float amount)
        {
            Date = date;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
        }
    }
}