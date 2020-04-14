using System;
using Xunit;

namespace CoffeeMachine.Test
{
    public class CoffeeMachineShould
    {
        [Fact]
        public void GetNewTeaObjectGivenDrinkType()
        {
            var drinkMaker = new DrinkMaker();
            var drink = drinkMaker.GetDrink(DrinkType.Tea);
            
            Assert.IsType<Tea>(drink);
        }
        
        [Fact]
        public void GetNewCoffeeObjectGivenDrinkType()
        {
            var drinkMaker = new DrinkMaker();
            var drink = drinkMaker.GetDrink(DrinkType.Coffee);
            
            Assert.IsType<Coffee>(drink);
        }
    }
}