using System;
using Xunit;

namespace CoffeeMachine.Test
{
    public class CoffeeMachineShould
    {
        private readonly DrinkMaker _drinkMaker;

        public CoffeeMachineShould()
        {
            _drinkMaker = new DrinkMaker();
        }
        
        [Fact]
        public void GetNewTeaObjectGivenDrinkType()
        {
            var drink = _drinkMaker.GetDrink(DrinkType.Tea);
            
            Assert.IsType<Tea>(drink);
        }
        
        [Fact]
        public void GetNewCoffeeObjectGivenDrinkType()
        {
            var drink = _drinkMaker.GetDrink(DrinkType.Coffee);
            
            Assert.IsType<Coffee>(drink);
        }
        
        [Fact]
        public void GetNewHotChocolateObjectGivenDrinkType()
        {
            var drink = _drinkMaker.GetDrink(DrinkType.HotChocolate);
            
            Assert.IsType<HotChocolate>(drink);
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
    }
}