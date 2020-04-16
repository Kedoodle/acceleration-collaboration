using System;
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

            var wasDrinkMade = _drinkMaker.TryMakeDrink(drinkCommand, out var drink);
            
            Assert.True(wasDrinkMade);
            Assert.Equal(DrinkType.Tea, drink.DrinkType);
            Assert.Equal(1, drink.Sugars);
            Assert.True(drink.HasStick());
        }

        [Fact]
        public void GetNewHotChocolateObjectGivenDrinkCommand()
        {
            const string drinkCommand = "H::";
            
            var wasDrinkMade = _drinkMaker.TryMakeDrink(drinkCommand, out var drink);
            
            Assert.True(wasDrinkMade);
            Assert.Equal(DrinkType.HotChocolate, drink.DrinkType);
            Assert.Equal(0, drink.Sugars);
            Assert.False(drink.HasStick());
        }
        
        [Fact]
        public void GetNewCoffeeObjectGivenDrinkCommand()
        {
            const string drinkCommand = "C:2:0";
            
            var wasDrinkMade = _drinkMaker.TryMakeDrink(drinkCommand, out var drink);
            
            Assert.True(wasDrinkMade);
            Assert.Equal(DrinkType.Coffee, drink.DrinkType);
            Assert.Equal(2, drink.Sugars);
            Assert.True(drink.HasStick());
        }
    }
}