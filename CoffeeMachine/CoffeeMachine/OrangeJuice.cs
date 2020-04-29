namespace CoffeeMachine
{
    public class OrangeJuice : IDrink
    {
 
            public DrinkType DrinkType { get; set; } = DrinkType.OrangeJuice;
            public int Sugars { get; set; }
        
            public bool HasStick()
            {
                return Sugars > 0;
            }
        }

}