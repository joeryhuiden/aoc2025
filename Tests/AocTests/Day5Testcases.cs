using Day3;

namespace AocTests;

[TestClass]
public class Day5Testcases
{
    [TestMethod]
    [DataRow("123", 23)]
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