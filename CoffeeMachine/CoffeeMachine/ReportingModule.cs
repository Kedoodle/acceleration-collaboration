using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeMachine
{
    public class ReportingModule
    {
        private StringBuilder _report;

        public ReportingModule()
        {
            Orders = new List<OrderDetails>();
        }
        
        public List<OrderDetails> Orders { get; }
        
        public void AddOrder(OrderDetails orderDetails)
        {
            Orders.Add(orderDetails);
        }

        public IEnumerable<char> GenerateReport(DateTime day)
        {
            _report = new StringBuilder();
            
            AddDate(day);
            AddDrinkCounts();
            AddTotalEarned();
            
            return _report.ToString();
        }

        private void AddDate(DateTime day)
        {
            _report.AppendLine($"Date: {day:dd-MMM-yyyy}");
        }

        private void AddDrinkCounts()
        {
            var drinkGroups = Orders.GroupBy(order => order.DrinkType)
                .OrderBy(order => order.Key.ToString());
            foreach (var drinkGroup in drinkGroups)
            {
                var drink = DrinkExtensions.ToFriendlyString(drinkGroup.Key);
                var count = drinkGroup.Count();
                _report.AppendLine($"{drink}: {count}");
            }
        }

        private void AddTotalEarned()
        {
            var total = Orders.Sum(order => order.AmountPaid);
            _report.Append($"Total Earned: ${total:N}");
        }
    }
}