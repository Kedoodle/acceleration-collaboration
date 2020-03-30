using System;
using string_calc_pair_prog;
using Xunit;

namespace string_calc_test
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyStringReturns0()
        {
            const int expected = 0;
            int actual = StringCalculator.Add("");
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(1, "1")]
        [InlineData(3, "3")]
        public void AddSingleNumberReturnsNumber(int expected, string stringToCalc)
        {
            var actual = StringCalculator.Add(stringToCalc);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, "1,2")]
        [InlineData(8, "3,5")]
        public void TwoNumbersReturnsSum(int expected, string stringToCalc)
        {
            var actual = StringCalculator.Add(stringToCalc);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6, "1,2,3")]
        [InlineData(20, "3,5,3,9")]
        public void AnyAmountOfNumbersReturnsSum(int expected, string stringToCalc)
        {
            var actual = StringCalculator.Add(stringToCalc);
            Assert.Equal(expected, actual);
            
        }

        [Theory]
        [InlineData(6, "1,2\n3")]
        [InlineData(20, "3\n5\n3,9")]
        public void LineBreaksAndCommasAreInterchangeable(int expected, string stringToCalc)
        {
            var actual = StringCalculator.Add(stringToCalc);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, "//;\n1;2")]
        [InlineData(5, "//,\n3,2")]
        public void DifferentDelimitersAreSupported(int expected, string stringToCalc)
        {
            var actual = StringCalculator.Add(stringToCalc);
            Assert.Equal(expected, actual);
            
        }
        
        
    }
}
