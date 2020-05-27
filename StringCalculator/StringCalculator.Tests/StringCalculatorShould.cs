using System;
using Xunit;

namespace StringCalculator.Tests
{
	public class StringCalculatorShould
	{
		[Fact]
		public void EmptyStringReturns0()
		{
			const int expected = 0;
			var actual = StringCalculator.Add("");
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
		[InlineData(3, "//[;]\n1;2")]
		[InlineData(5, "//[,]\n3,2")]
		public void DifferentDelimitersAreSupported(int expected, string stringToCalc)
		{
			var actual = StringCalculator.Add(stringToCalc);
			Assert.Equal(expected, actual);
			
		}
		
		[Theory]
		[InlineData("Negatives not allowed: -1, -3", "-1,2,-3")]
		[InlineData("Negatives not allowed: -20, -100", "-20,22,-100,-0")]
		public void NegativeNumbersThrowsException(string expectedExceptionMessage, string stringToCalc)
		{
			var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(stringToCalc));
			Assert.Equal(expectedExceptionMessage, exception.Message);
		}
		
		
		[Theory]
		[InlineData(2, "1000,1001,2")]
		[InlineData(999, "999,5000,0")]
		[InlineData(0, "1000")]
		public void NumbersGreaterThanOrEqualTo1000Ignored(int expected, string stringToCalc)
		{
			var actual = StringCalculator.Add(stringToCalc);
			Assert.Equal(expected, actual);
			
		}

		[Theory]
		[InlineData(6, "//[***]\n1***2***3")]
		public void DelimitersCanBeAnyLength(int expected, string stringToCalc)
		{
			var actual = StringCalculator.Add(stringToCalc);
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(6, "//[*][%]\n1*2%3")]
		public void AllowMultipleDelimitersOfOneChar(int expected, string stringToCalc)
		{
			var actual = StringCalculator.Add(stringToCalc);
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(10, "//[***][#][%]\n1***2#3%4")]
		public void AllowMultipleDelimitersOfMultipleChar(int expected, string stringToCalc)
		{
			var actual = StringCalculator.Add(stringToCalc);
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData(6, "//[*1*][%]\n1*1*2%3")]
		public void AllowMultipleDelimitersWithNumbers(int expected, string stringToCalc)
		{
			var actual = StringCalculator.Add(stringToCalc);
			Assert.Equal(expected, actual);
		}
	}
}
