using System;
using Xunit;

namespace StringCalculator.Tests
{
	public class StringCalculatorTest
	{
		private readonly StringCalculator _stringCalculator = new StringCalculator();
		
		[Theory]
		[InlineData("1", 1)]
		[InlineData("3", 3)]
		public void Add_SingleNumber_ShouldReturnItself(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);

			Assert.Equal(expectedResult, result);
		}

		[Theory]
		[InlineData("1,3", 1+3)]
		[InlineData("3,5", 3+5)]
		public void Add_TwoNumbers_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);

			Assert.Equal(expectedResult, result);
		}
		
		[Theory]
		[InlineData("1,2,3", 1+2+3)]
		[InlineData("3,5,3,9", 3+5+3+9)]
		public void Add_XNumbers_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);

			Assert.Equal(expectedResult, result);
		}
		
		[Theory]
		[InlineData("1,2\n3", 1+2+3)]
		[InlineData("3\n5\n3,9", 3+5+3+9)]
		public void Add_XNumbers_WithLineBreaks_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);

			Assert.Equal(expectedResult, result);
		}
		
		[Theory]
		[InlineData("//;\n1;2", 1+2)]
		[InlineData("//g\n3\n5\n3g9", 3+5+3+9)]
		public void Add_XNumbers_DifferentDelimiters_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);

			Assert.Equal(expectedResult, result);
		}
		
		[Theory]
		[InlineData("-1,2,-3")]
		public void Add_XNumbers_Negatives_ShouldThrowException(string value)
		{
			Assert.Throws<Exception>(() => _stringCalculator.Add(value));
		}
		
		[Theory]
		[InlineData("1000,1001,2", 2)]
		public void Add_XNumbers_IgnoreOver999_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);
			Assert.Equal(expectedResult, result);
		}
		
		[Theory]
		[InlineData("//[***]\n1***2***3", 1+2+3)]
		public void Add_XNumbers_AnyLengthDelimiter_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);
			Assert.Equal(expectedResult, result);
		}
		
		[Theory]
		[InlineData("//[*][%]\n1*2%3", 1+2+3)]
		public void Add_XNumbers_ManyDelimiters_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);
			Assert.Equal(expectedResult, result);
		}
		
		[Theory]
		[InlineData("//[***][#][%]\n1***2#3%4", 1+2+3+4)]
		public void Add_XNumbers_ManyAnyLengthDelimiters_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);
			Assert.Equal(expectedResult, result);
		}
		
		[Theory]
		[InlineData("//[*1*][%]\n1*1*2%3", 1+2+3)]
		public void Add_XNumbers_ManyAnyLengthDelimiters_WithNumbers_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);
			Assert.Equal(expectedResult, result);
		}
	}
}