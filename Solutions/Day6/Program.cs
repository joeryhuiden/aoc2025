using AocHelpers;

Console.WriteLine("Day 6!");

var inputs = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();
//var inputs = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\r\n") ?? throw new NotSupportedException();

Console.WriteLine($"Found {inputs.Count} inputs.");
Console.WriteLine($"Start solving...");

var operatorList = inputs.Last().Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
inputs.RemoveAt(inputs.Count - 1);
Console.WriteLine($"Amount of Columns: {operatorList.Count}");
Console.WriteLine($"Amount of Lines of numbers: {inputs.Count}");

var inputsEachLinePart1 = inputs.Select(l => l.Split((char[]?)null, operatorList.Count, StringSplitOptions.RemoveEmptyEntries)).Select(l => l.Select(long.Parse).ToArray()).ToArray();
var inputsEachLinePart2 = RotateInput([.. inputs])
            .Select(line => string.Concat(line).Trim())
            .ToArray();

long[] resultsPart1 = CalculatePart1(operatorList, inputsEachLinePart1);
List<long> resultsPart2 = CalculatePart2(operatorList, inputsEachLinePart2);

var resultPart1 = resultsPart1.Sum();
var resultPart2 = resultsPart2.Sum();

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();

static long[] CalculatePart1(List<string> operatorList, long[][] inputsEachLine)
{
    var resultsPart1 = inputsEachLine[0].ToArray();

    for (int i = 1; i < inputsEachLine.Length; i++)
    {
        for (int j = 0; j < inputsEachLine[i].Length; j++)
        {
            if (operatorList[j] == "+")
            {
                resultsPart1[j] += inputsEachLine[i][j];
            }
            if (operatorList[j] == "*")
            {
                resultsPart1[j] *= inputsEachLine[i][j];
            }
        }
    }

    return resultsPart1;
}

static List<long> CalculatePart2(List<string> operatorList, string[] inputsEachLine)
{
    var columnNumber = 0;
    long resultColumn = 0;
    var resultsPart2 = new List<long>();
    var reversedOperatorList = operatorList.AsEnumerable().Reverse().ToList();

    foreach (var value in inputsEachLine)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            resultsPart2.Add(resultColumn);
            resultColumn = 0;
            columnNumber++;
            continue;
        }

        if (resultColumn == 0)
        {
            resultColumn = long.Parse(value);
            continue;
        }
        if (reversedOperatorList[columnNumber] == "+")
        {
            resultColumn += long.Parse(value);
        }
        if (reversedOperatorList[columnNumber] == "*")
        {
            resultColumn *= long.Parse(value);
        }
    }

    resultsPart2.Add(resultColumn);

    return resultsPart2;
}

static string[] RotateInput(string[] input)
{
    int width = input[0].Length;
    int height = input.Length;

    char[][] newMatrix = new char[width][];
    for (int x = 0; x < width; x++)
    {
        newMatrix[x] = new char[height];
    }

    for (int oldY = 0; oldY < height; oldY++)
    {
        for (int oldX = 0; oldX < width; oldX++)
        {
            var newY = width - oldX - 1;
            var newX = oldY;
            newMatrix[newY][newX] = input[oldY][oldX];
        }
    }

    return [.. newMatrix.Select(row => string.Concat(row))];
}