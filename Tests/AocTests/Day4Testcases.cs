using Day3;

namespace AocTests;

[TestClass]
public class Day4Testcases
{
    [TestMethod]
    [DataRow("values", 0)]
    public void Part1_ReturnsExpected(string input, int expectedResult)
    {
        // Arrange
        var inputNumbers = input.Select(c => c.ToString()).ToArray() ?? [];

        // Act
        int result = JoltageFinder.FindMaxJoltage(inputNumbers);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}