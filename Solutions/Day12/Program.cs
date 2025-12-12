using AocHelpers;

Console.WriteLine("Day 12!");

var lines = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();
//var lines = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\r\n") ?? throw new NotSupportedException();

Console.WriteLine($"Found {lines.Count} lines.");
Console.WriteLine($"Start solving...");

// Split input into presents with index and amount of spaces used and a list of areas.
var presents = new Dictionary<int, int>();
var areas = new List<string>();
var findingPresent = true;
var lineIndex = 0;

while(findingPresent)
{
    var indexLine = lines[lineIndex];
    if (indexLine.Contains('x'))
    {
        findingPresent = false;
        break;
    }

    var index = int.Parse(indexLine[..indexLine.IndexOf(':')]);
    var presentArea = 0;

    for (var y = 1; y < 4; y++)
    {
        presentArea += lines[lineIndex + y].Count(c => c == '#');
    }

    presents.Add(index, presentArea);
    lineIndex += 5;
}

// Start solving Part 1
var resultPart1 = 0;
for (int i = lineIndex; i < lines.Count; i++)
{
    var line = lines[i];
    var area = int.Parse(line[..line.IndexOf('x')]) * int.Parse(line[(line.IndexOf('x') + 1)..line.IndexOf(':')]);
    var presentCounts = line[(line.IndexOf(":") + 2)..].Split(' ');

    var neededSpaceForPresents = 0;
    for (var x = 0; x < presentCounts.Length; x++)
    {
        var amountOfPresents = int.Parse(presentCounts[x]);
        neededSpaceForPresents += amountOfPresents * presents[x];
    }

    if (neededSpaceForPresents < area)
    {
        resultPart1++;
    }
}

var resultPart2 = 0;

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();