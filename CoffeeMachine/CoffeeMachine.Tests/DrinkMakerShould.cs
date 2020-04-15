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
        public void GetNewTeaObjectGivenDrinkType()
        {
            var drink = _drinkMaker.GetDrink(DrinkType.Tea);
            
            Assert.IsType<Tea>(drink);
            Assert.True(drink.DrinkType == DrinkType.Tea);
        }
        
        [Fact]
        public void GetNewCoffeeObjectGivenDrinkType()
        {
            var drink = _drinkMaker.GetDrink(DrinkType.Coffee);
            
            Assert.IsType<Coffee>(drink);
            Assert.True(drink.DrinkType == DrinkType.Coffee);
        }
        
        [Fact]
        public void GetNewHotChocolateObjectGivenDrinkType()
        {
            var drink = _drinkMaker.GetDrink(DrinkType.HotChocolate);
            
            Assert.IsType<HotChocolate>(drink);
            Assert.True(drink.DrinkType == DrinkType.HotChocolate);
        }

        [Fact]
        public void AddSugarToNewDrinks()
        {
            const int sugars = 1;
            var drink = _drinkMaker.GetDrink(DrinkType.Tea, sugars);
            
            Assert.Equal(sugars, drink.Sugars);
        }

        [Fact]
        public void AddStickIfDrinkHasSugar()
        {
            const int sugars = 1;
            var drink = _drinkMaker.GetDrink(DrinkType.Tea, sugars);
            
            Assert.True(drink.HasStick());
        }
        
        [Fact]
        public void NotAddStickIfDrinkHasSugar()
        {
            const int sugars = 0;
            var drink = _drinkMaker.GetDrink(DrinkType.Tea, sugars);
            
            Assert.False(drink.HasStick());
        }
    }
}