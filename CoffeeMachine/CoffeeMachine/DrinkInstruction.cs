namespace CoffeeMachine
{
    public class DrinkInstruction : IInstruction
    {
        public DrinkInstruction(DrinkType drinkType, int sugars, bool isExtraHot)
        {
            DrinkType = drinkType;
            Sugars = sugars;
            IsExtraHot = isExtraHot;
        }
        public DrinkType DrinkType { get; }
        public int Sugars { get; }
        
        public bool IsExtraHot { get;  }
    }
}