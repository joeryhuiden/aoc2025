using AocHelpers;
using System.Drawing;

Console.WriteLine("Day 7!");

var inputs = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n").ToArray() ?? throw new NotSupportedException();
//var inputs = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\r\n").ToArray() ?? throw new NotSupportedException();

Console.WriteLine($"Found {inputs.Length} lines.");
Console.WriteLine($"Start solving...");

bool[] beams = new bool[inputs.First().Length];
var resultPart1 = 0;

beams[inputs.First().IndexOf('S')] = true; // Mark Starting Beam.

for (int n = 2; n < inputs.Length; n += 2)
{
    var row = inputs[n];
    for (int i = 0; i < row.Length; i++)
    {
        if (IsSplitter(row[i]) && beams[i])
        {
            beams[i] = false; // Current position no beam.
            beams[i + 1] = true; // Beam right for next iteration.
            beams[i - 1] = true; // Beam left for next iteration.
            resultPart1 += 1; // Add split to counter for part 1.
        }
    }
}

Dictionary<BeamPosition, long> memoryOfPaths = [];
var resultPart2 = CalculateWorldsPart2(memoryOfPaths, inputs, new BeamPosition(inputs.First().IndexOf('S'), 0));

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();

static long CalculateWorldsPart2(Dictionary<BeamPosition, long> memoryOfPaths, string[] grid, BeamPosition beam)
{
    // If the beam position is already registrerd, don't create a new one, but return it's value so that all the paths can be calculated.
    if (memoryOfPaths.TryGetValue(beam, out long counterOfWorlds))
    {
        return counterOfWorlds;
    }

    // At the end, return 1 so that all the paths before can be calculated.
    if (grid.Length == beam.Row + 1)
    {
        return 1;
    }

    // If there is a splitter, calculate the new world paths.
    if (IsSplitter(grid[beam.Row + 1][beam.Column]))
    {
        // Splitter found, branch out and sum worlds.
        var newWorlds = CalculateWorldsPart2(memoryOfPaths, grid, new BeamPosition(beam.Column + 1, beam.Row + 1))
            + CalculateWorldsPart2(memoryOfPaths, grid, new BeamPosition(beam.Column - 1, beam.Row + 1));
        memoryOfPaths.Add(beam, newWorlds);
    }
    else
    {
        // No splitter, continue downwards.
        memoryOfPaths.Add(beam, CalculateWorldsPart2(memoryOfPaths,grid, new BeamPosition(beam.Column, beam.Row + 1)));
    }

    // return the amount of paths from this beam position (and all paths that you constructed before).
    return memoryOfPaths[beam];
}

static bool IsSplitter(char toCheck) => toCheck == '^';

record BeamPosition(int Column, int Row);