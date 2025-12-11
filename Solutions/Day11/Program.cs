using AocHelpers;
using Day11;

Console.WriteLine("Day 11!");

var inputs = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();
//var inputs = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\n") ?? throw new NotSupportedException();
//var inputs = InputFileReader.ReadInputFileToObjects<string>("./inputExamplePart2.txt", "\n") ?? throw new NotSupportedException();

var devices = inputs.Select(Device.Parse).ToList();
devices.Add(new Device("out"));

foreach (var device in devices)
{
    device.LookUpDevices(devices);
}

Console.WriteLine($"Found {devices.Count} Devices.");
Console.WriteLine($"Start solving...");

// Part 1
//var startingDevicePart1 = devices.First(d => d.Name.Equals("you", StringComparison.OrdinalIgnoreCase));
//var resultPart1 = startingDevicePart1.CountAmountOfPathsTo("out");
var resultPart1 = 0;

// Part 2
var resultPart2 = CalculatePart2(devices);

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();

static long CalculatePart2(List<Device> devices)
{
    var startingDevicePart2 = devices.First(d => d.Name.Equals("svr", StringComparison.OrdinalIgnoreCase));
    var passingPointFftPart2 = devices.First(d => d.Name.Equals("fft", StringComparison.OrdinalIgnoreCase));
    var passingPointDacPart2 = devices.First(d => d.Name.Equals("dac", StringComparison.OrdinalIgnoreCase));

    // Assume svr-fft-dac-out
    var sequence1 = startingDevicePart2.CountAmountOfPathsTo("fft") * passingPointFftPart2.CountAmountOfPathsTo("dac") * passingPointDacPart2.CountAmountOfPathsTo("out");
    // Assume svr-dac-fft-out
    var sequence2 = startingDevicePart2.CountAmountOfPathsTo("dac") * passingPointDacPart2.CountAmountOfPathsTo("fft") * passingPointFftPart2.CountAmountOfPathsTo("out");
    return sequence1 + sequence2;
}