namespace CoffeeMachine
{
    public class DrinkMaker
    {
        private readonly IMoneyModule _moneyModule;
        private readonly IEmailNotifier _emailNotifier;
        private readonly IBeverageQuantityChecker _beverageQuantityChecker;

        public DrinkMaker(IMoneyModule moneyModule, IEmailNotifier emailNotifier, IBeverageQuantityChecker beverageQuantityChecker)
        {
            _moneyModule = moneyModule;
            _emailNotifier = emailNotifier;
            _beverageQuantityChecker = beverageQuantityChecker;
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
                    if (_beverageQuantityChecker.IsEmpty(drinkInstruction.DrinkType))
                    {
                        _emailNotifier.NotifyMissingDrink(drinkInstruction.DrinkType);
                        Message = "There is not enough water or milk";
                        return false;
                    }
                    Message = _moneyModule.GetOrderTotalMessage();
                    _moneyModule.RequestMoney();
                    if (!_moneyModule.IsOrderPaid())
                    {
                        Message = _moneyModule.GetOrderNotPaidMessage();
                        return false;
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