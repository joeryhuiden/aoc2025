using AocHelpers;
using Day3;
using System.Numerics;

Console.WriteLine("Day 3!");

var banks = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();

Console.WriteLine($"Found {banks.Count} inputs.");
Console.WriteLine($"Start solving...");

int resultPart1 = 0;
BigInteger resultPart1WithPart2Solution = 0;
BigInteger resultPart2 = 0;

foreach (var bank in banks)
{
    if (string.IsNullOrEmpty(bank))
    {
        continue;
    }

    var numbers = bank.Select(c => c.ToString()).ToArray();

    var maxJoltagePart1 = JoltageFinder.FindMaxJoltage(numbers);
    var maxJoltagePart1Alternative = JoltageFinder.FindMaxJoltagePart2(numbers, 2);
    var maxJoltagePart2 = JoltageFinder.FindMaxJoltagePart2(numbers, 12);
    resultPart1 += maxJoltagePart1;
    resultPart1WithPart2Solution += maxJoltagePart1Alternative;
    resultPart2 += maxJoltagePart2;
}

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1}");
Console.WriteLine($"result part one with Part 2 solution: {resultPart1WithPart2Solution}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();
