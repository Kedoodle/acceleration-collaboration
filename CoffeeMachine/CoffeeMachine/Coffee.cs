namespace CoffeeMachine
{
    public class Coffee : IDrink
    {
        public DrinkType DrinkType { get; } = DrinkType.Coffee;
        public int Sugars { get; set; }
        public bool IsExtraHot { get; set; }

        public bool HasStick()
        {
            return Sugars > 0;
        }
    }
}