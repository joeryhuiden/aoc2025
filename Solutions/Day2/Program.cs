using AocHelpers;
using Day2;
using System.Numerics;

Console.WriteLine("Day 1!");

var inputs = InputFileReader.ReadInputFileToObjects<string>("./input.txt", ",") ?? throw new NotSupportedException();

Console.WriteLine($"Found {inputs.Count} inputs.");

BigInteger resultPart1 = 0;
BigInteger resultPart2 = 0;

foreach (var range in inputs)
{
    var rangeNumbers = range.Split('-');

    if (!BigInteger.TryParse(rangeNumbers[0], out var startNumber) ||
        !BigInteger.TryParse(rangeNumbers[1], out var endNumber) ||
        startNumber > endNumber)
    {
        throw new NotSupportedException();
    }

    var result = RangeValidator.ValidateRange(startNumber, endNumber);
    resultPart1 += result.Item1;
    resultPart2 += result.Item2;
}

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();

