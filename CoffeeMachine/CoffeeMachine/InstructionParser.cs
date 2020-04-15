using System.Collections.Generic;

namespace CoffeeMachine
{
    public static class InstructionParser
    {
        private static readonly Dictionary<string, DrinkType> _drinkCodes = new Dictionary<string, DrinkType>()
        {
            {"T", DrinkType.Tea},
            {"H", DrinkType.HotChocolate},
            {"C", DrinkType.Coffee}
        };
        
        public static bool TryParse(string drinkCommand, out DrinkInstruction drinkInstruction)
        {
            var stringDrinkComponents = drinkCommand.Split(':');

            var drinkType = _drinkCodes[stringDrinkComponents[0]];
            int.TryParse(stringDrinkComponents[1], out var sugars);

            drinkInstruction = new DrinkInstruction(drinkType, sugars);
            return true;
        }
    }
}