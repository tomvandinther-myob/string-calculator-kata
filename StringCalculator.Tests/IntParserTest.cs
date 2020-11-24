using Xunit;

namespace StringCalculator.Tests
{
    public class IntParserTest
    {
        IntParser _intParser = new IntParser();

        [Theory]
        [InlineData("1,2", new int[] { 1, 2 })]
        [InlineData("1,2\n3", new int[] { 1, 2, 3 })]
        [InlineData("3\n5\n3,9", new int[] { 3, 5, 3, 9 })]
        [InlineData("//;\n1;2", new int[] { 1, 2 })]
        [InlineData("1000,1001,2", new int[] { 2 })]
        [InlineData("//[***]\n1***2***3", new int[] { 1, 2, 3 })]
        public void ParseInts_ShouldReturnIntArray(string value, int[] expectedResult)
        {
            var result = _intParser.ParseInts(value);
                
            Assert.Equal(expectedResult, result);
        }
    }
}