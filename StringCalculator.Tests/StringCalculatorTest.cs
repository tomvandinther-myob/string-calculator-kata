using Xunit;

namespace StringCalculator.UnitTests
{
	public class StringCalculatorTest
	{
		private readonly StringCalculator _stringCalculator = new StringCalculator();
		
		[Theory]
		[InlineData("1")]
		[InlineData("3")]
		public void Add_String_ShouldReturnItself(string value)
		{
			var result = _stringCalculator.Add(value);
			var expectedResult = int.Parse(value);

			Assert.Equal(expectedResult, result); // How to annotate a test with a description?
		}
	}
}