using System;

namespace CoffeeMachine
{
    public interface IMoneyModule
    {
        DrinkType DrinkOrder { get; set; }
        decimal AmountPaid { get; set; }
        string GetOrderTotalMessageCommand();
        public bool IsOrderPaid();
        void RequestMoney();
    }
}