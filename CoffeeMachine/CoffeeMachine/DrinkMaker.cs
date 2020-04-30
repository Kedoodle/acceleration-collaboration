namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public IDrink Drink { get; private set; }
        public string Message { get; private set; }

        public IMoneyModule MoneyModule { get; set; }
        
        public bool TryExecuteCommand(string command)
        {
            InstructionParser.TryParse(command, out var instruction);
            switch (instruction)
            {
                case DrinkInstruction drinkInstruction:
                    if (HasMoneyModule())
                    {
                        var messageCommand = MoneyModule.GetOrderTotalMessageCommand(drinkInstruction.DrinkType);
                        TryExecuteCommand(messageCommand);
                        MoneyModule.RequestMoney(drinkInstruction.DrinkType);
                        if (!MoneyModule.IsOrderPaid()) return false;
                    }
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

        private bool HasMoneyModule()
        {
            return !(MoneyModule is null);
        }

        private static string ErrorMessage(ErrorMessageInstruction errorMessageInstruction)
        {
            return errorMessageInstruction.ErrorMessage;
        }

        private static string GetMessage(MessageInstruction messageInstruction)
        {
            return messageInstruction.Message;
        }

        private static IDrink GetDrink(DrinkInstruction drinkInstruction)
        {
            return new Drink(drinkInstruction.DrinkType, drinkInstruction.Sugars, drinkInstruction.IsExtraHot);
        }
    }
}