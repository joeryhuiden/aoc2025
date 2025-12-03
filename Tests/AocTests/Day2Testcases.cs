using Day2;

namespace AocTests;

[TestClass]
public class Day2Testcases
{
    [TestMethod]
    [DataRow("1", true)]
    [DataRow("11", false)]
    [DataRow("22", false)]
    [DataRow("101", true)]
    [DataRow("1010", false)]
    public void IsValidNumber_ReturnsExpected(string input, bool expectedResult)
    {
        // Act
        bool result = RangeValidator.ValidateNumber(input);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow("11", false)]
    [DataRow("22", false)]
    [DataRow("111", false)]
    [DataRow("101", true)]
    [DataRow("1010", false)]
    [DataRow("824824824", false)]
    [DataRow("2121212121", false)]
    public void IsValidNumberPart2_ReturnsExpected(string input, bool expectedResult)
    {
        // Act
        bool result = RangeValidator.ValidateNumberPart2(input);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow(11, 22, 33)]
    [DataRow(95, 115, 99)]
    [DataRow(998, 1012, 1010)]
    public void RangeValidator_ReturnsCorrectNumberForPart1(int start, int end, int expectedResult)
    {
        // Act
        var result = RangeValidator.ValidateRange(start, end);

        // Assert
        Assert.AreEqual(expectedResult, result.Item1);
    }


    [TestMethod]
    [DataRow(11, 22, 33)]
    [DataRow(95, 115, 210)]
    [DataRow(998, 1012, 2009)]
    public void RangeValidator_ReturnsCorrectNumberForPart2(int start, int end, int expectedResult)
    {
        // Act
        var result = RangeValidator.ValidateRange(start, end);

        // Assert
        Assert.AreEqual(expectedResult, result.Item2);
    }
}
