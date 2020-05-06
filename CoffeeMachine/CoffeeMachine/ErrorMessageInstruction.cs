namespace CoffeeMachine
{
    public class ErrorMessageInstruction : IInstruction
    {
        public string ErrorMessage { get; }

        public ErrorMessageInstruction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}