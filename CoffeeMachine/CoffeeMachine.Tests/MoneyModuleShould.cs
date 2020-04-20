using Xunit;

namespace CoffeeMachine.Test
{
    public class MoneyModuleShould
    {

        [Fact]
        public void DetermineEnoughMoneyForTea()
        {
            var moneyModule = new MoneyModule {DrinkOrder = DrinkType.Tea, AmountPaid = 0.4m};
            Assert.True(moneyModule.IsOrderPaid());
        }

        [Fact]
        public void DetermineNotEnoughMoneyForTea()
        {
            var moneyModule = new MoneyModule {DrinkOrder = DrinkType.Tea, AmountPaid = 0.2m};
            Assert.False(moneyModule.IsOrderPaid());
        }
        
    }
}