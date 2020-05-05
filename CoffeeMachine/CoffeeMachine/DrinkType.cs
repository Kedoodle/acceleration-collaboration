using System.ComponentModel;

namespace CoffeeMachine
{
    public enum DrinkType
    {
        Tea,
        Coffee,
        HotChocolate,
        OrangeJuice
    }
    public static class DrinkExtensions
    {
        public static string ToFriendlyString(DrinkType drinkType)
        {
            return drinkType switch
            {
                DrinkType.Tea => "Tea",
                DrinkType.Coffee => "Coffee",
                DrinkType.HotChocolate => "Hot Chocolate",
                DrinkType.OrangeJuice => "Orange Juice",
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}