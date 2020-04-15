namespace CoffeeMachine
{
    public class Tea : IDrink
    {
        public DrinkType DrinkType { get; set; } = DrinkType.Tea;
        public int Sugars { get; set; }
        
        public bool HasStick()
        {
            return Sugars > 0;
        }
    }
}