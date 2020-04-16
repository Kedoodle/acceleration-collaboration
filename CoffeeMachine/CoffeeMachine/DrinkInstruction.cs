namespace CoffeeMachine
{
    public struct DrinkInstruction : IInstruction
    {
        public DrinkInstruction(DrinkType drinkType, int sugars)
        {
            DrinkType = drinkType;
            Sugars = sugars;
        }
        public DrinkType DrinkType { get; }
        public int Sugars { get; }
    }
}