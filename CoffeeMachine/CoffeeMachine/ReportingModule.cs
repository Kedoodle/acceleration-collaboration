using System.Collections.Generic;

namespace CoffeeMachine.Tests
{
    public class ReportingModule
    {
        public List<OrderDetails> Orders { get; } = new List<OrderDetails>();
        
        public void AddOrder(OrderDetails orderDetails)
        {
            Orders.Add(orderDetails);
        }
    }
}