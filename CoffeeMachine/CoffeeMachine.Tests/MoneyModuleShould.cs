using Moq;
using Xunit;

namespace CoffeeMachine.Test
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
        [InlineData(DrinkType.Coffee, "M:ORDER TOTAL: $0.60")]
        [InlineData(DrinkType.Tea, "M:ORDER TOTAL: $0.40")]
        [InlineData(DrinkType.HotChocolate, "M:ORDER TOTAL: $0.50")]
        [InlineData(DrinkType.OrangeJuice, "M:ORDER TOTAL: $0.60")]
        public void GetOrderTotalMessageCommand(DrinkType drinkType, string expectedMessageCommand)
        {
            var moneyModule = new MoneyModule {DrinkOrder = drinkType};
            var actualMessageCommand = moneyModule.GetOrderTotalMessageCommand();
            
            Assert.Equal(expectedMessageCommand, actualMessageCommand);
        }
        
        
        [Theory]
        [InlineData(DrinkType.Coffee, 0.40, "M:INSUFFICIENT PAYMENT: Additional $0.20 required")]
        [InlineData(DrinkType.Tea, 0.10, "M:INSUFFICIENT PAYMENT: Additional $0.30 required")]
        [InlineData(DrinkType.HotChocolate, 0.49, "M:INSUFFICIENT PAYMENT: Additional $0.01 required")]
        [InlineData(DrinkType.OrangeJuice, 0.03, "M:INSUFFICIENT PAYMENT: Additional $0.57 required")]
        
        public void GetOrderNotPaidMessageCommand(DrinkType drinkType, decimal amountPaid, string expectedMessageCommand)
        {
            var moneyModule = new MoneyModule {DrinkOrder = drinkType, AmountPaid = amountPaid};
            var actualMessageCommand = moneyModule.GetOrderNotPaidMessageCommand();
            
            Assert.Equal(expectedMessageCommand, actualMessageCommand);
        }
    }
}