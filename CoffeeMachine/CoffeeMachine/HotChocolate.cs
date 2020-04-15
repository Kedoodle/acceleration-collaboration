namespace CoffeeMachine
{
    public class HotChocolate : IDrink
    {
        public DrinkType DrinkType { get; set; } = DrinkType.Coffee;
        public int Sugars { get; set; }
        
        public bool HasStick()
        {
            return Sugars > 0;
        }
    }
}