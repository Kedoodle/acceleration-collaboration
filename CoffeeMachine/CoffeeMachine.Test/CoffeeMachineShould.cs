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
            var tea = drinkMaker.GetDrink(DrinkType.Tea);
            
            Assert.IsType<Tea>(tea);
        }
    }

}