using System;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public IDrink GetDrink(DrinkType drinkType, int sugars = 0)
        {
            switch (drinkType)
            {
                case DrinkType.Tea:
                    return new Tea {Sugars = sugars};
                case DrinkType.Coffee:
                    return new Coffee {Sugars = sugars};
                case DrinkType.HotChocolate:
                    return new HotChocolate {Sugars = sugars};
                default:
                    throw new ArgumentOutOfRangeException(nameof(drinkType), drinkType, null);
            }
        }
    }
}