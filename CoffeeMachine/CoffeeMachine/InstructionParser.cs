using System.Collections.Generic;
using System.Linq;

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
            if (IsMessageCommand(command))
            {
                instruction = GetMessageInstruction(command);
                return true;
            }
            
            if (IsDrinkCommand(command))
            {
                instruction = GetDrinkInstruction(command);
                return true;
            }
            
            instruction = new ErrorMessageInstruction("Invalid command code!");
            return false;
        }

        private static bool IsMessageCommand(string command)
        {
            const string messageCommandCode = "M:";
            return command.StartsWith(messageCommandCode);
        }

        private static IInstruction GetMessageInstruction(string command)
        {
            var message = command.Length == 2 ? "" : command.Substring(2);
            return new MessageInstruction(message);
        }
        
        private static bool IsDrinkCommand(string command)
        {
            var validDrinkCommands = new[] {"C:", "T:", "H:", "O:", "Ch:", "Th:", "Hh"};
            return validDrinkCommands.Any(command.StartsWith);
        }

        private static IInstruction GetDrinkInstruction(string command)
        {
            var instructionComponents = command.Split(":");
            var drinkType = GetDrinkType(instructionComponents);
            var sugars = GetSugars(instructionComponents);
            var isExtraHot = GetIsExtraHot(instructionComponents);
            return new DrinkInstruction(drinkType, sugars, isExtraHot);
        }
        
        private static DrinkType GetDrinkType(string[] instructionComponents)
        {
            var drinkCode = instructionComponents[0][0];
            return _drinkCodes[drinkCode];
        }

        private static int GetSugars(string[] instructionComponents)
        {
            var sugarInstruction = instructionComponents[1];
            int.TryParse(sugarInstruction, out var sugars);
            return sugars;
        }

        private static bool GetIsExtraHot(string[] instructionComponents)
        {

            var drinkComponent = instructionComponents[0];
            return drinkComponent.Length > 1 && drinkComponent[1] == 'h';
        }
    }
}