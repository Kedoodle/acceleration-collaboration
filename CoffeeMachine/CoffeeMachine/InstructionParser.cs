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
        
        public static bool TryParse(string command, out IInstruction instruction)
        {
            var instructionComponents = command.Split(':');

            if (instructionComponents[0] == "M")
            {
                instruction = new MessageInstruction(instructionComponents[1]);
                return true;
            }

            if (_drinkCodes.ContainsKey(instructionComponents[0]))
            {
                var drinkType = _drinkCodes[instructionComponents[0]];
                int.TryParse(instructionComponents[1], out var sugars);
                
                instruction = new DrinkInstruction(drinkType, sugars);
                return true;
            }

            instruction = new ErrorMessageInstruction("Invalid command code!");
            return false;
        }
    }
}