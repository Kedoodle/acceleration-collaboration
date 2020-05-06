namespace CoffeeMachine
{
    public interface IEmailNotifier
    {
        void NotifyMissingDrink(DrinkType drinkType);
    }
}