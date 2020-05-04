using System;

namespace CoffeeMachine.Tests
{
    public class OrderDetails
    {
        public OrderDetails(DrinkType drinkType, decimal amountPaid)
        {
            TimeStamp = DateTime.Now;
            DrinkType = drinkType;
            AmountPaid = amountPaid;
        }
        
        public DateTime TimeStamp { get; }
        public DrinkType DrinkType { get; }
        public decimal AmountPaid { get; }

    }
}