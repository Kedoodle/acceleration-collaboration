using Xunit;

namespace CoffeeMachine.Tests
{
    public class MoneyModuleShould
    {
       
        [Theory]
        [InlineData(DrinkType.Coffee, 0.6)]
        [InlineData(DrinkType.Tea, 0.4)]
        [InlineData(DrinkType.HotChocolate, 0.5)]
        public void DetermineEnoughMoneyForDrinkOrder(DrinkType drinkOrder, decimal amountPaid)
        {
            var moneyModule = new MoneyModule {DrinkOrder = drinkOrder, AmountPaid = amountPaid};
            Assert.True(moneyModule.IsOrderPaid());
        }

        [Theory]
        [InlineData(DrinkType.Coffee, 0.5)]
        [InlineData(DrinkType.Tea, 0.2)]
        [InlineData(DrinkType.HotChocolate, 0.4)]
        public void DetermineNotEnoughMoneyForDrinkOrder(DrinkType drinkOrder, decimal amountPaid)
        {
            var moneyModule = new MoneyModule {DrinkOrder = drinkOrder, AmountPaid = amountPaid};
            Assert.False(moneyModule.IsOrderPaid());
        }
        
        [Theory]
        [InlineData(DrinkType.Coffee, "ORDER TOTAL: $0.60")]
        [InlineData(DrinkType.Tea, "ORDER TOTAL: $0.40")]
        [InlineData(DrinkType.HotChocolate, "ORDER TOTAL: $0.50")]
        [InlineData(DrinkType.OrangeJuice, "ORDER TOTAL: $0.60")]
        public void GetOrderTotalMessage(DrinkType drinkType, string expectedMessage)
        {
            var moneyModule = new MoneyModule {DrinkOrder = drinkType};
            var actualMessage = moneyModule.GetOrderTotalMessage();
            
            Assert.Equal(expectedMessage, actualMessage);
        }
        
        
        [Theory]
        [InlineData(DrinkType.Coffee, 0.40, "INSUFFICIENT PAYMENT: Additional $0.20 required")]
        [InlineData(DrinkType.Tea, 0.10, "INSUFFICIENT PAYMENT: Additional $0.30 required")]
        [InlineData(DrinkType.HotChocolate, 0.49, "INSUFFICIENT PAYMENT: Additional $0.01 required")]
        [InlineData(DrinkType.OrangeJuice, 0.03, "INSUFFICIENT PAYMENT: Additional $0.57 required")]
        
        public void GetOrderNotPaidMessage(DrinkType drinkType, decimal amountPaid, string expectedMessage)
        {
            var moneyModule = new MoneyModule {DrinkOrder = drinkType, AmountPaid = amountPaid};
            var actualMessage = moneyModule.GetOrderNotPaidMessage();
            
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}