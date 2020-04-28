using System;

namespace CoffeeMachine
{
    public interface IMoneyModule
    {
        decimal AmountPaid { get; set; }
        string GetOrderTotalMessageCommand(DrinkType drinkType);
        public bool IsOrderPaid();
        void RequestMoney(DrinkType drinkType);
    }
}