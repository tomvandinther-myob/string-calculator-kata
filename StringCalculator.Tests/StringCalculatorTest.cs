using Xunit;

namespace StringCalculator.UnitTests
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
		[InlineData("\n\n3,9", 3+5+3+9)]
		public void Add_XNumbers_WithLineBreaks_ShouldReturnSum(string value, int expectedResult)
		{
			var result = _stringCalculator.Add(value);

			Assert.Equal(expectedResult, result);
		}
	}
}