using System;
using Moq;
using Xunit;

namespace CoffeeMachine.Test
{
    public class DrinkMakerShould
    {
        private IMoneyModule _dummyMoneyModule;

        public DrinkMakerShould()
        {
            _dummyMoneyModule = Mock.Of<IMoneyModule>();
        }
        
        
        [Theory]
        [InlineData("T:1:0", DrinkType.Tea, 1, true)]
        [InlineData("H::", DrinkType.HotChocolate, 0, false)]
        [InlineData("C:2:0", DrinkType.Coffee, 2, true)]
        [InlineData("O::", DrinkType.OrangeJuice, 0, false)]
        public void CreateDifferentDrinksGivenDrinkCommand(string drinkCommand, DrinkType expectedDrinkType, int expectedSugars, bool expectedStick )
        {
            var stubMoneyModule = Mock.Of<IMoneyModule>(m => 
                    m.GetOrderTotalMessage() == "M:" &&
                    m.IsOrderPaid());
            
            var drinkMaker = new DrinkMaker(stubMoneyModule);
            var wasCommandExecuted = drinkMaker.TryExecuteCommand(drinkCommand);
            var drink = drinkMaker.Drink;
            
            Assert.True(wasCommandExecuted);
            Assert.Equal(expectedDrinkType, drink.DrinkType);
            Assert.Equal(expectedSugars, drink.Sugars);
            Assert.Equal(expectedStick, drink.HasStick());
        }
        
        [Theory]
        [InlineData("Ch::", DrinkType.Coffee, 0, false, true)]
        [InlineData("Hh:1:0", DrinkType.HotChocolate, 1, true, true)]
        [InlineData("Th:2:0", DrinkType.Tea, 2, true, true)]
        public void CreateDifferentExtraHotDrinksGivenDrinkCommand(string drinkCommand, DrinkType expectedDrinkType, int expectedSugars, bool expectedStick, bool expectedExtraHot )
        {
            var stubMoneyModule = Mock.Of<IMoneyModule>(m => 
                m.GetOrderTotalMessage() == "M:" &&
                m.IsOrderPaid());
            
            var drinkMaker = new DrinkMaker(stubMoneyModule);
            var wasCommandExecuted = drinkMaker.TryExecuteCommand(drinkCommand);
            var drink = drinkMaker.Drink;
            
            Assert.True(wasCommandExecuted);
            Assert.Equal(expectedDrinkType, drink.DrinkType);
            Assert.Equal(expectedSugars, drink.Sugars);
            Assert.Equal(expectedStick, drink.HasStick());
            Assert.Equal(expectedExtraHot, drink.IsExtraHot);
        }
        
        [Fact]
        public void FailsGivenInvalidCommandCode()
        {
            var drinkMaker = new DrinkMaker(_dummyMoneyModule);
            const string invalidCommand = "Z";
            var wasCommandExecuted = drinkMaker.TryExecuteCommand(invalidCommand);
            var drink = drinkMaker.Drink;

            Assert.False(wasCommandExecuted);
            Assert.Null(drink);
        }

        [Fact]
        public void ForwardMessageReceived()
        {
            var drinkMaker = new DrinkMaker(_dummyMoneyModule);
            
            const string messageCommand = "M:message-content";
            const string expectedMessage = "message-content";
            
            var wasCommandExecuted = drinkMaker.TryExecuteCommand(messageCommand);
            var drink = drinkMaker.Drink;
            var message = drinkMaker.Message;

            Assert.True(wasCommandExecuted);
            Assert.Null(drink);
            Assert.Equal(expectedMessage, message);
        }

        [Fact]
        public void RequestPaymentIfMoneyModuleUsed()
        {
            var mockMoneyModule = Mock.Of<IMoneyModule>(m => 
                m.GetOrderTotalMessage() == "M:Order Total: $0.60" &&
                m.AmountPaid == 0.60m);
            var drinkMaker = new DrinkMaker(mockMoneyModule);

            const string drinkCommand = "C:2:0";
            drinkMaker.TryExecuteCommand(drinkCommand);
            
            Mock.Get(mockMoneyModule).Verify(m => 
                m.GetOrderTotalMessage(), Times.Once);
        }
        
    }
}
