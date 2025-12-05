using AocHelpers;
using Day5;
using System.Numerics;

Console.WriteLine("Day 5!");

var linesInInput = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();
//var inputs = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\n") ?? throw new NotSupportedException();

Console.WriteLine($"Found {linesInInput.Count} input lines.");
Console.WriteLine($"Start solving...");

var ranges = new List<FreshRange>();
var inputIds = new List<long>();

foreach (var line in linesInInput)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        continue;
    }
    else if (line.Contains('-'))
    {
        var parts = line.Split('-');
        ranges.Add(new FreshRange(long.Parse(parts[0]), long.Parse(parts[1])));
    }
    else
    {
        inputIds.Add(long.Parse(line));
    }
}

Console.WriteLine($"Found {ranges.Count} input Ranges.");
Console.WriteLine($"Found {inputIds.Count} input ID's.");

var freshnessValidator = new FreshnessValidator(ranges);
var amountOfRangesAfterMerge = freshnessValidator.KeepCombiningOverlappingRangesUntilDone();
Console.WriteLine($"Amount of ranges after merging: {amountOfRangesAfterMerge}.");

var resultPart1 = inputIds.Count(freshnessValidator.IsItemFresh);
Console.WriteLine($"result part one: {resultPart1}");

var resultPart2 = freshnessValidator.GetAmountOfFreshnessIds();

Console.WriteLine($"result part two: {resultPart2}");
Console.WriteLine("Done!");
Console.ReadKey();