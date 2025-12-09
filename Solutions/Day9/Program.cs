using AocHelpers;

Console.WriteLine("Day 9!");

var inputs = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();
//var inputs = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\r\n") ?? throw new NotSupportedException();

Console.WriteLine($"Found {inputs.Count} inputs.");
Console.WriteLine($"Start solving...");

var tiles = inputs
    .Select(line => line.Split(','))
    .Select(parts => new Tile(long.Parse(parts[0]), long.Parse(parts[1])))
    .ToList();

// For Part 2 we need to create lines from the tiles.
List<Line> lines = CreateLinesFromTiles(tiles);

var resultPart1 = 0L;
var resultPart2 = 0L;
for (var i = 0; i < tiles.Count - 1; i++)
{
    for (var j = i + 1; j < tiles.Count; j++)
    {
        var areaSize = CalculateArea(tiles[i], tiles[j]);

        if (areaSize > resultPart1)
        {
            resultPart1 = areaSize;
        }

        // For Part 2, look if any line intersects with the rectangle if the area is bigger then the current biggest.
        if (areaSize > resultPart2 && !lines.Any(line => line.Intersects(tiles[i], tiles[j])))
        {
            resultPart2 = areaSize;
        }
    }
}

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();

static long CalculateArea(Tile tile1, Tile tile2) =>
    (Math.Abs(tile1.X - tile2.X) + 1) *
    (Math.Abs(tile1.Y - tile2.Y) + 1);

static List<Line> CreateLinesFromTiles(List<Tile> tiles)
{
    var lines = new List<Line>();
    for (var i = 0; i < tiles.Count - 1; i++)
    {
        lines.Add(new Line(tiles[i], tiles[i + 1]));
    }
    lines.Add(new Line(tiles[^1], tiles[0]));
    return lines;
}

record Tile(long X, long Y);

record struct Line(Tile Start, Tile End)
{
    public readonly bool Intersects(Tile tile1, Tile tile2)
    {
        var minX = Math.Min(tile1.X, tile2.X);
        var maxX = Math.Max(tile1.X, tile2.X);
        var minY = Math.Min(tile1.Y, tile2.Y);
        var maxY = Math.Max(tile1.Y, tile2.Y);

        var lineMinX = Math.Min(Start.X, End.X);
        var lineMaxX = Math.Max(Start.X, End.X);
        var lineMinY = Math.Min(Start.Y, End.Y);
        var lineMaxY = Math.Max(Start.Y, End.Y);

        return lineMaxX > minX && lineMinX < maxX && lineMaxY > minY && lineMinY < maxY;
    }
}