using System;

namespace CoffeeMachine
{
    public interface IMoneyModule
    {
        DrinkType DrinkOrder { get; set; }
        decimal AmountPaid { get; set; }
        string GetOrderTotalMessage();
        public bool IsOrderPaid();
        string GetOrderNotPaidMessage();
        void RequestMoney();
    }
}