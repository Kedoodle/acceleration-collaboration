using System.Collections.Generic;

namespace CoffeeMachine
{
    public static class InstructionParser
    {
        private static readonly Dictionary<char, DrinkType> _drinkCodes = new Dictionary<char, DrinkType>()
        {
            {'T', DrinkType.Tea},
            {'H', DrinkType.HotChocolate},
            {'C', DrinkType.Coffee},
            {'O', DrinkType.OrangeJuice}
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
                case "Ch":
                case "Th":
                case "Hh":
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
            var drinkType = GetDrinkType(instructionComponents);
            var sugars = GetSugars(instructionComponents);
            var isExtraHot = GetIsExtraHot(instructionComponents);
            return new DrinkInstruction(drinkType, sugars, isExtraHot);
        }

        private static bool GetIsExtraHot(string[] instructionComponents)
        {

            var drinkComponent = instructionComponents[0];
            return drinkComponent.Length > 1 && drinkComponent[1] == 'h';
        }

        private static int GetSugars(string[] instructionComponents)
        {
            var sugarInstruction = instructionComponents[1];
            int.TryParse(sugarInstruction, out var sugars);
            return sugars;
        }


        private static DrinkType GetDrinkType(string[] instructionComponents)
        {
            var drinkCode = instructionComponents[0][0];
            return _drinkCodes[drinkCode];
        }

    }
}