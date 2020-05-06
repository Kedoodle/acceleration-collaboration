namespace CoffeeMachine
{
    public class DrinkMaker
    {
        private readonly IMoneyModule _moneyModule;

        public DrinkMaker(IMoneyModule moneyModule)
        {
            _moneyModule = moneyModule;
        }

        public IDrink Drink { get; private set; }
        public string Message { get; private set; }
        
        public bool TryExecuteCommand(string command)
        {
            InstructionParser.TryParse(command, out var instruction);
            switch (instruction)
            {
                case DrinkInstruction drinkInstruction:
                    _moneyModule.DrinkOrder = drinkInstruction.DrinkType;
                    var messageCommand = _moneyModule.GetOrderTotalMessageCommand();
                    TryExecuteCommand(messageCommand);
                    _moneyModule.RequestMoney();
                    if (!_moneyModule.IsOrderPaid()) return false;
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