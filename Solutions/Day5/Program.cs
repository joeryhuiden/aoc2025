using AocHelpers;

Console.WriteLine("Day 5!");

//var inputs = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();
var inputs = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\n") ?? throw new NotSupportedException();

Console.WriteLine($"Found {inputs.Count} inputs.");
Console.WriteLine($"Start solving...");

var resultPart1 = 0;
var resultPart2 = 0;

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();