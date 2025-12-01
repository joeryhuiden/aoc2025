using AocHelpers;

Console.WriteLine("Day 1!");

var currentpoint = 50;
var lowpoint = 0;
var maxpoint = 99;
var passingpoint = 0;
var passedCount = 0;
int zeroCount = 0;

var inputs = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n");

Console.WriteLine($"Found {inputs.Count} inputs.");

foreach (var input in inputs)
{
    // Calaculate Part two.
    zeroCount += CountPassingPointPassed(currentpoint, input);

    var newpoint = CalculateNewPoint(currentpoint, input, lowpoint, maxpoint);
    if (newpoint == passingpoint)
    {
        passedCount++;
    }

    currentpoint = newpoint;
}

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {passedCount}");
Console.WriteLine($"result part two: {passedCount} + {zeroCount - passedCount} = {zeroCount}");
Console.ReadKey();

static int CalculateNewPoint(int currentpoint, string rotatingInstruction, int lowpoint, int maxpoint)
{
    var rotatingLeft = rotatingInstruction.Contains('L');
    var rotatingTicks = int.Parse(rotatingInstruction[1..]) * (rotatingLeft ? -1 : 1);

    var newPoint = currentpoint + rotatingTicks;

    if (newPoint > maxpoint)
    {
        while (newPoint > maxpoint)
        {
            newPoint = lowpoint + (newPoint - maxpoint - 1);
        }
    }
    else if (newPoint < lowpoint)
    {
        while (newPoint < lowpoint)
        {
            newPoint = maxpoint - (lowpoint - newPoint - 1);
        }
    }

    return newPoint;
}

static int CountPassingPointPassed(int startValue, string rotation)
{
    int distance = Convert.ToInt32(rotation[1..]);
    int step = rotation[0] == 'R' ? 1 : -1;
    int zeroCount = 0;

    foreach (var _ in Enumerable.Range(0, distance))
    {
        startValue += step;
        startValue %= 100;
        if (startValue == 0)
            zeroCount++;
    }

    return zeroCount;
}