using System;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        // public DrinkMaker(MoneyModule)
        // {
        //     
        // }
        // public bool TryMakeDrink(string drinkCommand, out IDrink drink)
        // {
        //     InstructionParser.TryParse(drinkCommand, out var drinkInstruction);
        //     drink = GetDrink(drinkInstruction);
        //     return true;
        // }

        public IDrink Drink { get; private set; }
        public string Message { get; set; }

        public IMoneyModule MoneyModule { get; set; }
        
        public bool TryExecuteCommand(string command)
        {
            InstructionParser.TryParse(command, out var instruction);
            switch (instruction)
            {
                case DrinkInstruction drinkInstruction:
                    if (!(MoneyModule is null))
                    {
                        var messageCommand = MoneyModule.RequestMoney(drinkInstruction);
                        TryExecuteCommand(messageCommand);
                    }
                    
                    //ask for user input
                    //user inputs amount paid
                    //check if enough money
                    //if amount is not enough, return false
                    Drink = GetDrink(drinkInstruction);
                    return true;
                case MessageInstruction messageInstruction:
                    Message = GetMessage(messageInstruction);
                    return true;
                case ErrorMessageInstruction errorMessageInstruction:
                    Message = ErrorMessage(errorMessageInstruction);
                    return false;
                default:
                    return false;
            }
        }
        
        //function check if moneymodule is used

        private static string ErrorMessage(ErrorMessageInstruction errorMessageInstruction)
        {
            return errorMessageInstruction.ErrorMessage;
        }

        private static string GetMessage(MessageInstruction messageInstruction)
        {
            return messageInstruction.Message;
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