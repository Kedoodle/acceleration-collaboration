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
        
    }
}