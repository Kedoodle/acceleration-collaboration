using System.Collections.Generic;

namespace fizzbuzz
{
    public static class FizzBuzzer
    {
        public static string Generate(int number)
        {
            if (IsMultipleOf3(number) && IsMultipleOf5(number)) return "FizzBuzz";
            if (IsMultipleOf3(number)) return "Fizz";
            if (IsMultipleOf5(number)) return "Buzz";
            return number.ToString();
        }
        
        private static bool IsMultipleOf3(int number)
        {
            return number % 3 == 0;
        }

        private static bool IsMultipleOf5(int number)
        {
            return number % 5 == 0;
        }
    }
}