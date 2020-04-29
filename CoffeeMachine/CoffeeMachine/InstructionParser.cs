using System.Collections.Generic;
using System.Net.Http.Headers;

namespace CoffeeMachine
{
    public static class InstructionParser
    {
        private static readonly Dictionary<string, DrinkType> _drinkCodes = new Dictionary<string, DrinkType>()
        {
            {"T", DrinkType.Tea},
            {"H", DrinkType.HotChocolate},
            {"C", DrinkType.Coffee},
            {"O", DrinkType.OrangeJuice}
        };
        
        public static bool TryParse(string command, out IInstruction instruction)
        {
            //TODO: refactor this function to a validator function
            if (command.Length < 2)
            {
                instruction = new ErrorMessageInstruction("Invalid command code!");
                return false;
                
            }
            switch (command.Substring(0, 2))
            {
                case "M:":
                    instruction = GetMessageInstruction(command);
                    return true;
                case "C:":
                case "T:":
                case "H:":
                case "O:":
                    instruction = GetDrinkInstruction(command);
                    return true;
                default:
                    instruction = new ErrorMessageInstruction("Invalid command code!");
                    return false;
            }
        }
        
        private static IInstruction GetMessageInstruction(string command)
        {
            var message = command.Length == 2 ? "" : command.Substring(2);
            return new MessageInstruction(message);
        }


        private static IInstruction GetDrinkInstruction(string command)
        {
            var instructionComponents = command.Split(":");
            var drinkType = GetDrinkType(instructionComponents[0]);
            var sugarInstruction = instructionComponents[1];
            int.TryParse(sugarInstruction, out var sugars);
            return new DrinkInstruction(drinkType, sugars);
        }


        private static DrinkType GetDrinkType(string drinkCode)
        {
            return _drinkCodes[drinkCode];
        }

    }
}