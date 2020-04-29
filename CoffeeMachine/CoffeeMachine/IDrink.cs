namespace CoffeeMachine
{
    public interface IDrink
    {
        DrinkType DrinkType { get;}
        int Sugars { get; set; }
        bool IsExtraHot { get; set; }
        bool HasStick();

    }
}