namespace CoffeeMachine
{
    public interface IMoneyModule
    {
        string GetOrderTotalMessageCommand(DrinkInstruction drinkInstruction);
    }
}