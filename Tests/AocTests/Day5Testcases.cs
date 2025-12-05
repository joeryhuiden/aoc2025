using Day5;

namespace AocTests;

[TestClass]
public class Day5Testcases
{
    [TestMethod]
    [DataRow("1-3", 1, true)]
    [DataRow("1-3", 2, true)]
    [DataRow("1-3", 3, true)]
    [DataRow("1-3", 4, false)]
    [DataRow("1-3", 0, false)]
    public void IsItemFreshPart1_ReturnsExpected(string range, int id, bool expectedResult)
    {
        // Arrange
        var parts = range.Split('-');
        var freshRange = new List<FreshRange> { new(long.Parse(parts[0]), long.Parse(parts[1])) };
        var sut = new FreshnessValidator(freshRange);

        // Act
        bool result = sut.IsItemFresh(id);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow(1, 3, 3)]
    [DataRow(10, 14, 5)]
    [DataRow(16, 20, 5)]
    public void GetAmountInRangePart2_ReturnsExpected(int min, int max, int expectedResult)
    {
        // Arrange
        var sut = new FreshRange(min, max);

        // Act
        var result = sut.GetNumberOfFreshIdsInRange();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}