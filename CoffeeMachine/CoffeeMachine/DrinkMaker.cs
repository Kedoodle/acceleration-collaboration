namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public IDrink GetDrink(DrinkType drinkType)
        {
            return new Tea();
        }
    }
}