using System;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public IDrink GetDrink(DrinkType drinkType)
        {
            switch (drinkType)
            {
                case DrinkType.Tea:
                    return new Tea();
                case DrinkType.Coffee:
                    return new Coffee();
                default:
                    throw new ArgumentOutOfRangeException(nameof(drinkType), drinkType, null);
            }
        }
    }
}