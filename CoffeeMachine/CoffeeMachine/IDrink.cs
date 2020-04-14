namespace CoffeeMachine
{
    public interface IDrink
    {
        int Sugars { get; set; }
        bool HasStick();
    }
}