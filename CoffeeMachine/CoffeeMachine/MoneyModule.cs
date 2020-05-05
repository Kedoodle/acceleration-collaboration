using System;

namespace CoffeeMachine
{
    public class MoneyModule : IMoneyModule
    {
        public DrinkType DrinkOrder { get; set; }
        public decimal AmountPaid { get; set; }
        
        public bool IsOrderPaid()
        {
            return AmountPaid >= GetDrinkPrice();
        }
        
        private decimal GetDrinkPrice()
        {
            return DrinkExtensions.GetPrice(DrinkOrder);
        }

        public string GetOrderTotalMessageCommand()
        {
            var drinkPrice = GetDrinkPrice();
            return $"M:ORDER TOTAL: ${drinkPrice:F}";
        }
        
        public string GetOrderNotPaidMessageCommand()
        {
            var drinkPrice = GetDrinkPrice();
            var additionalPayment = drinkPrice - AmountPaid;
            return $"M:INSUFFICIENT PAYMENT: Additional ${additionalPayment:F} required";
        }

        public void RequestMoney()
        {
            AmountPaid = GetUserPayment();
        }
        
        private decimal GetUserPayment()
        {
            return decimal.Parse(Console.ReadLine() ?? throw new ArgumentNullException());
        }
    }
}