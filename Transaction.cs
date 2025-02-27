namespace SupportBank
{
    class Transaction
    {
        public DateOnly Date {get;}
        public string From {get;}
        public string To { get;}
        public string Narrative {get;}
        public int Amount {get;}

        public Transaction(DateOnly date, string from, string to, string narrative, int amount)
        {
            Date = date;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
        }
    }
}