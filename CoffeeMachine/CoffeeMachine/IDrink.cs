namespace CoffeeMachine
{
    public interface IDrink
    {
        DrinkType DrinkType { get; }
        int Sugars { get; }
        bool IsExtraHot { get; }
        bool HasStick();
    }
}
