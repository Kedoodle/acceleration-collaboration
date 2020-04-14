namespace CoffeeMachine
{
    public class Drink : IDrink
    {
        public int Sugars { get; set; }
        
        public bool HasStick()
        {
            return Sugars > 0;
        }
    }
}