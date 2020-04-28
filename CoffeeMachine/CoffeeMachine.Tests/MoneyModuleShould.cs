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
        [InlineData(DrinkType.Coffee, "M:Order Total: $0.60")]
        [InlineData(DrinkType.Tea, "M:Order Total: $0.40")]
        [InlineData(DrinkType.HotChocolate, "M:Order Total: $0.50")]
        public void GetOrderTotalMessageCommand(DrinkType drinkType, string expectedMessageCommand)
        {
            var moneyModule = new MoneyModule();
            var actualMessageCommand = moneyModule.GetOrderTotalMessageCommand(drinkType);
            
            Assert.Equal(expectedMessageCommand, actualMessageCommand);
        }
    }
}