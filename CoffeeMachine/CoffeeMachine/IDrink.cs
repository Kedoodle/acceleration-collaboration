namespace CoffeeMachine
{
    public interface IDrink
    {
        DrinkType DrinkType { get; set; }
        int Sugars { get; set; }
        bool HasStick();
    }
}