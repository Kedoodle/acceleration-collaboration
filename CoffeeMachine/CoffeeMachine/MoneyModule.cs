using System.Collections.Generic;

namespace CoffeeMachine
{
    public class MoneyModule
    {
        private readonly Dictionary<DrinkType, decimal> _drinkPrices = new Dictionary<DrinkType, decimal>()
        {
            {DrinkType.Coffee, 0.6m},
            {DrinkType.Tea, 0.4m},
            {DrinkType.HotChocolate, 0.5m}
        };

        public DrinkType DrinkOrder { get; set; }
        public decimal AmountPaid { get; set; }


        private decimal GetPrice()
        {
            return _drinkPrices[DrinkOrder];
        }


        public bool IsOrderPaid()
        {
            return AmountPaid >= GetPrice();
        }
    }
}