namespace SupportBank
{
    class User
    {
        public string Name { get; set; }
        public float AmountUserOwes { get; set; }
        public float AmountUserIsOwed { get; set; }

        public User(string name, float amountuserowes, float amountuserisowed)
        {
            Name = name;
            AmountUserOwes = amountuserowes;
            AmountUserIsOwed = amountuserisowed;
        }
    }
}