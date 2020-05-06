namespace CoffeeMachine
{
    public interface IBeverageQuantityChecker
    {
        bool IsEmpty(DrinkType drinkType);
    }
}