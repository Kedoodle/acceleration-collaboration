namespace CoffeeMachine
{
    public class MessageInstruction : IInstruction
    {
        public string Message { get; }

        public MessageInstruction(string message)
        {
            Message = message;
        }
    }
}