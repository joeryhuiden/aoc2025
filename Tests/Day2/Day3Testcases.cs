using Day2;
using Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AocTests;

[TestClass]
public class Day3Testcases
{
    [TestMethod]
    [DataRow("987654321111111", 98)]
    [DataRow("811111111111119", 89)]
    [DataRow("234234234234278", 78)]
    [DataRow("818181911112111", 92)]
    [DataRow("3646122246265233144266436235253422621132626544356324544665325242262222212765227332424562134252555523", 77)]
    public void FindMaxJoltage_ReturnsExpected(string input, int expectedResult)
    {
        // Arrange
        var inputNumbers = input.Select(c => c.ToString()).ToArray() ?? [];

        // Act
        int result = JoltageFinder.FindMaxJoltage(inputNumbers);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow("987654321111111", "987654321111")]
    [DataRow("811111111111119", "811111111119")]
    [DataRow("234234234234278", "434234234278")]
    [DataRow("818181911112111", "888911112111")]
    public void FindMaxJoltagePart2_ReturnsExpected(string input, string expectedResult)
    {
        // Arrange
        var inputNumbers = input.Select(c => c.ToString()).ToArray() ?? [];

        // Act
        BigInteger result = JoltageFinder.FindMaxJoltagePart2(inputNumbers, 12);

        // Assert
        Assert.AreEqual(expectedResult, result.ToString());
    }

    [TestMethod]
    [DataRow("987654321111111", 98)]
    [DataRow("811111111111119", 89)]
    [DataRow("234234234234278", 78)]
    [DataRow("818181911112111", 92)]
    [DataRow("3646122246265233144266436235253422621132626544356324544665325242262222212765227332424562134252555523", 77)]
    public void FindMaxJoltageAlternativeUsingPart2_ReturnsExpected(string input, int expectedResult)
    {
        // Arrange
        var inputNumbers = input.Select(c => c.ToString()).ToArray() ?? [];

        // Act
        var result = JoltageFinder.FindMaxJoltagePart2(inputNumbers, 2);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
