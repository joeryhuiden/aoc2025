using AocHelpers;
using Day10;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;

Console.WriteLine("Day 10!");

var inputs = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();
//var inputs = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\r\n") ?? throw new NotSupportedException();

Console.WriteLine($"Found {inputs.Count} inputs.");
Console.WriteLine($"Start solving...");

var machines = inputs
    .Select((input, index) => Machine.FromInputString(input, index))
    .ToList();

//var resultsPart1 = new ConcurrentBag<int>();
//Parallel.ForEach(machines, machine =>
//{
//    resultsPart1.Add(machine.TryToSolveMachinePart1());
//});

//var resultPart1 = resultsPart1.Sum();
//Console.WriteLine($"result part one: {resultPart1}");

var resultsPart2 = new ConcurrentBag<int>();
Parallel.ForEach(machines, new ParallelOptions
{
    MaxDegreeOfParallelism = 4 // Limit to a maximum of 4 concurrent tasks
}, machine =>
{
    resultsPart2.Add(machine.TryToSolveMachinePart2());
});

var resultPart2 = resultsPart2.Sum();

Console.WriteLine($"result part two: {resultPart2}");
Console.WriteLine("Done!");
Console.ReadKey();