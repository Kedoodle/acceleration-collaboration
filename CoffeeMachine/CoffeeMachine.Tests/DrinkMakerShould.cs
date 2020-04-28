using System;
using Moq;
using Xunit;

namespace CoffeeMachine.Test
{
    public class DrinkMakerShould
    {
        private readonly DrinkMaker _drinkMaker;

        public DrinkMakerShould()
        {
            _drinkMaker = new DrinkMaker();
        }
        
        [Fact]
        public void GetNewTeaObjectGivenDrinkCommand()
        {
            const string drinkCommand = "T:1:0";

            var wasCommandExecuted = _drinkMaker.TryExecuteCommand(drinkCommand);
            var drink = _drinkMaker.Drink;
            
            Assert.True(wasCommandExecuted);
            Assert.Equal(DrinkType.Tea, drink.DrinkType);
            Assert.Equal(1, drink.Sugars);
            Assert.True(drink.HasStick());
        }

        [Fact]
        public void GetNewHotChocolateObjectGivenDrinkCommand()
        {
            const string drinkCommand = "H::";
            
            var wasCommandExecuted = _drinkMaker.TryExecuteCommand(drinkCommand);
            var drink = _drinkMaker.Drink;

            Assert.True(wasCommandExecuted);
            Assert.Equal(DrinkType.HotChocolate, drink.DrinkType);
            Assert.Equal(0, drink.Sugars);
            Assert.False(drink.HasStick());
        }
        
        [Fact]
        public void GetNewCoffeeObjectGivenDrinkCommand()
        {
            const string drinkCommand = "C:2:0";
            
            var wasCommandExecuted = _drinkMaker.TryExecuteCommand(drinkCommand);
            var drink = _drinkMaker.Drink;

            Assert.True(wasCommandExecuted);
            Assert.Equal(DrinkType.Coffee, drink.DrinkType);
            Assert.Equal(2, drink.Sugars);
            Assert.True(drink.HasStick());
        }
        
        [Fact]
        public void FailsGivenInvalidCommandCode()
        {
            const string invalidCommand = "Z";
            
            var wasCommandExecuted = _drinkMaker.TryExecuteCommand(invalidCommand);
            var drink = _drinkMaker.Drink;

            Assert.False(wasCommandExecuted);
            Assert.Null(drink);
        }

        [Fact]
        public void ForwardMessageReceived()
        {
            const string messageCommand = "M:message-content";
            const string expectedMessage = "message-content";
            
            var wasCommandExecuted = _drinkMaker.TryExecuteCommand(messageCommand);
            var drink = _drinkMaker.Drink;
            var message = _drinkMaker.Message;

            Assert.True(wasCommandExecuted);
            Assert.Null(drink);
            Assert.Equal(expectedMessage, message);
        }

        [Fact]
        public void RequestPaymentIfMoneyModuleUsed()
        {
            var mockMoneyModule = Mock.Of<IMoneyModule>(m => 
                m.GetOrderTotalMessageCommand(It.IsAny<DrinkType>()) == "M:Order Total: $0.60" &&
                m.AmountPaid == 0.60m);
            _drinkMaker.MoneyModule = mockMoneyModule;
            
            const string drinkCommand = "C:2:0";
            _drinkMaker.TryExecuteCommand(drinkCommand);
            
            Mock.Get(mockMoneyModule).Verify(m => 
                m.GetOrderTotalMessageCommand(It.IsAny<DrinkType>()), Times.Once);
        }
    }
}
