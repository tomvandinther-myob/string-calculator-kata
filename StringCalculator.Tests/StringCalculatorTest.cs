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
	}
}