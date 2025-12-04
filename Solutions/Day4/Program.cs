using AocHelpers;

Console.WriteLine("Day 4!");

var rows = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();
//var rows = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\n") ?? throw new NotSupportedException();

Console.WriteLine($"Found {rows.Count} inputs.");
Console.WriteLine($"Start solving...");

char[,] grid = InitializeGrid(rows);

PrintGrid(grid);

var resultPart1 = FindAccessable(grid);
var resultOfIteration = FindAccessable(grid);
var resultPart2 = resultOfIteration.Item2;

while (resultOfIteration.Item2 > 0)
{
    resultOfIteration = FindAccessable(resultOfIteration.Item1);

    resultPart2 += resultOfIteration.Item2;
    //PrintGrid(resultOfIteration.Item1);
}

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1.Item2}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();

(char[,], int) FindAccessable(char[,] oldGrid)
{
    var newGrid = new char[oldGrid.GetLength(0), oldGrid.GetLength(1)];
    var countOfMarked = 0;
    // Populate the grid (e.g., with the . or @)
    for (int i = 0; i < oldGrid.GetLength(0); i++)
    {
        for (int j = 0; j < oldGrid.GetLength(1); j++)
        {
            if (oldGrid[i, j] == '.' || oldGrid[i, j] == 'X')
            {
                newGrid[i, j] = '.';
                continue;
            }

            var listOfAdjacent = GetAdjacents(oldGrid, i, j);
            if (listOfAdjacent.Where(c => c == '@').Count() >= 4)
            {
                newGrid[i, j] = '@';
            } 
            else
            {
                newGrid[i, j] = 'X';
                countOfMarked++;
            }
        }
    }

    return (newGrid, countOfMarked);
}

static List<char> GetAdjacents(char[,] grid, int i, int j)
{
    var adjacents = new List<char>();

    for (int x = -1; x < 2; x++)
    {
        for (int y = -1; y < 2; y++)
        {
            var rowIndex = i + x;
            var colIndex = j + y;

            if (rowIndex == -1 || colIndex == -1 || rowIndex >= grid.GetLength(0) || colIndex >= grid.GetLength(1) || (x == 0 && y == 0))
            {
                continue;
            }

            adjacents.Add(grid[rowIndex, colIndex]);
        }
    }

    return adjacents;
}

static char[,] InitializeGrid(List<string> rows)
{
    // Create Grid
    char[,] grid = new char[rows.Count, rows[0].Length];

    // Fill in the grid (e.g., with the . or @)
    for (int i = 0; i < rows.Count; i++)
    {
        for (int j = 0; j < rows[i].Length; j++)
        {
            grid[i, j] = rows[i][j];
        }
    }

    return grid;
}

static void PrintGrid(char[,] grid)
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            Console.Write(grid[i, j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}