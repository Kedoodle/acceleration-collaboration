using System;
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

        public static decimal GetPrice(DrinkType drinkType)
        {
            return drinkType switch
            {
                DrinkType.Tea => 0.4m,
                DrinkType.Coffee => 0.6m,
                DrinkType.HotChocolate => 0.5m,
                DrinkType.OrangeJuice => 0.6m,
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}