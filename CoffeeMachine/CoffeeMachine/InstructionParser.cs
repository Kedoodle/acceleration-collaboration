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
            
            if (IsMessage(instructionComponents))
            {
                instruction = GetMessageInstruction(instructionComponents);
                return true;
            }

            if (IsDrink(instructionComponents))
            {
                instruction = GetDrinkInstruction(instructionComponents);
                return true;
            }

            instruction = new ErrorMessageInstruction("Invalid command code!");
            return false;
        }
        
        private static bool IsMessage(string[] instructionComponents)
        {
            var instructionType = GetInstructionType(instructionComponents);
            return instructionType == "M";
        }
        
        private static string GetInstructionType(string[] instructionComponents)
        {
            return instructionComponents[0];
        }

        private static IInstruction GetMessageInstruction(string[] instructionComponents)
        {
            var message = instructionComponents[1];
            return new MessageInstruction(message);
        }

        private static bool IsDrink(string[] instructionComponents)
        {
            var instructionType = GetInstructionType(instructionComponents);
            return _drinkCodes.ContainsKey(instructionType);
        }

        private static IInstruction GetDrinkInstruction(string[] instructionComponents)
        {
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