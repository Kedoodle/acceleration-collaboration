using System;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public bool TryMakeDrink(string drinkCommand, out IDrink drink)
        {
            InstructionParser.TryParse(drinkCommand, out var drinkInstruction);
            drink = GetDrink(drinkInstruction);
            return true;
        }
        
        private IDrink GetDrink(DrinkInstruction drinkInstruction)
        {
            switch (drinkInstruction.DrinkType)
            {
                case DrinkType.Tea:
                    return new Tea {Sugars = drinkInstruction.Sugars};
                case DrinkType.Coffee:
                    return new Coffee {Sugars = drinkInstruction.Sugars};
                case DrinkType.HotChocolate:
                    return new HotChocolate {Sugars = drinkInstruction.Sugars};
                default:
                    throw new ArgumentOutOfRangeException(nameof(drinkInstruction.DrinkType), drinkInstruction.DrinkType, null);
            }
        }
    }
}