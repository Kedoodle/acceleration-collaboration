namespace CoffeeMachine
{
    public class HotChocolate : IDrink
    {
        public DrinkType DrinkType { get; } = DrinkType.HotChocolate;
        public int Sugars { get; set; }

        public bool IsExtraHot { get; set; }

        public bool HasStick()
        {
            return Sugars > 0;
        }
    }
}