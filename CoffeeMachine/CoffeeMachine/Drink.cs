namespace CoffeeMachine
{
    public class Drink : IDrink
    {
        public Drink(DrinkType drinkType, int sugars, bool isExtraHot)
        {
            DrinkType = drinkType;
            Sugars = sugars;
            IsExtraHot = isExtraHot;
        }
        
        public DrinkType DrinkType { get; }
        public int Sugars { get; }
        public bool IsExtraHot { get; }
        public bool HasStick()
        {
            return Sugars > 0;
        }
    }
}