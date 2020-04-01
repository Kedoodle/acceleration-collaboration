using System;
using fizzbuzz;
using Xunit;

namespace fizzbuzz_tests
{
    public class FizzBuzzerTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("4", 4)]
        [InlineData("7", 7)]
        public void Generate_GivenNonMultiple_ReturnNumber(string expected, int number)
        {
            var actual = FizzBuzzer.Generate(number);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("Fizz", 3)]
        [InlineData("Fizz", 6)]
        [InlineData("Fizz", 9)]
        [InlineData("Fizz", 12)]
        public void Generate_GivenMultipleOf3Not5_ReturnFizz(string expected, int number)
        {
            var actual = FizzBuzzer.Generate(number);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("Buzz", 5)]
        [InlineData("Buzz", 10)]
        [InlineData("Buzz", 20)]
        public void Generate_GivenMultipleOf5Not3_ReturnBuzz(string expected, int number)
        {
            var actual = FizzBuzzer.Generate(number);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("FizzBuzz", 15)]
        [InlineData("FizzBuzz", 30)]
        [InlineData("FizzBuzz", 45)]
        public void Generate_GivenMultipleOf15_ReturnFizzBuzz(string expected, int number)
        {
            var actual = FizzBuzzer.Generate(number);
            Assert.Equal(expected, actual);
        }
    }
}