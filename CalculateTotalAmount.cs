using System.Dynamic;

namespace SupportBank
{
    class CalculateTotalAmount
    {
        public static void CalculateTotalUserOwes(List<Transaction> transactions, User user )
        {
           foreach(Transaction transactionitem in transactions)
           {   
               if ( transactionitem.To == user.Name)
               {
                    user.AmountUserOwes += transactionitem.Amount;
               }
           }
        }
        public static void CalculateTotalUserIsOwed(List<Transaction> transactions, User user )
        {
           foreach(Transaction transactionitem in transactions)
           {   
               if ( transactionitem.From == user.Name)
               {
                    user.AmountUserIsOwed += transactionitem.Amount;
               }
           }
        }
    }
}