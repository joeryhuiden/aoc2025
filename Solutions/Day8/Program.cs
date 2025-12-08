using AocHelpers;

Console.WriteLine("Day 8!");

var inputs = InputFileReader.ReadInputFileToObjects<string>("./input.txt", "\n") ?? throw new NotSupportedException();
//var inputs = InputFileReader.ReadInputFileToObjects<string>("./inputExample.txt", "\r\n") ?? throw new NotSupportedException();

Console.WriteLine($"Found {inputs.Count} Junction Boxes.");
Console.WriteLine($"Start solving...");

// Convert input to JunctionBoxes.
var boxes = inputs
    .Select(line => line.Split(','))
    .Select(parts => new JunctionBox(long.Parse(parts[0]), long.Parse(parts[1]), long.Parse(parts[2])))
    .ToList();

// Get all connections with distances and sort them by distance.
var connections = CalculateConnections(boxes).OrderBy(c => c.Distance).ToList();

// Create circuits (each circuit is a single junction box, it's without any connection for now).
var circuits = new List<HashSet<JunctionBox>>();
foreach (var box in boxes)
{
    circuits.Add([box]);
}

// Loop 1000 times (or 10 for example) through the list of connections with the shortest distance.
var iterations = inputs.Count > 20 ? 1000 : 10;
int i;
for (i = 0; i < iterations; i++)
{
    circuits = ConnectCircuits(circuits, connections[i]);
}

var resultPart1 = circuits[0].Count * circuits[1].Count * circuits[2].Count;

// For part 2 we continue looping until all boxes connected with a circuit.
while(circuits.Any(c => c.Count == 1))
{
    circuits = ConnectCircuits(circuits, connections[i]);
    i++;
}

var lastConnection = connections[i - 1];

var resultPart2 = lastConnection.From.X * lastConnection.To.X;

Console.WriteLine("Done!");
Console.WriteLine($"result part one: {resultPart1}");
Console.WriteLine($"result part two: {resultPart2}");
Console.ReadKey();

static List<Connection> CalculateConnections(List<JunctionBox> boxes)
{
    // Loop through all boxes and calculate distances and add them to a list.
    var result = new List<Connection>();
    for (var i = 0; i < boxes.Count - 1; i++)
    {
        var box1 = boxes[i];

        for (var j = i + 1; j < boxes.Count; j++)
        {
            var boxB = boxes[j];
            result.Add(new Connection(box1, boxB, CalculateDistance(box1, boxB)));
        }
    }

    return result;
}

static long CalculateDistance(JunctionBox box1, JunctionBox box2) => 
    (long)Math.Sqrt(Math.Pow(box1.X - box2.X, 2) + Math.Pow(box1.Y - box2.Y, 2) + Math.Pow(box1.Z - box2.Z, 2));

static List<HashSet<JunctionBox>> ConnectCircuits(List<HashSet<JunctionBox>> circuits, Connection shortestConnection)
{
    // Find the circuits from both junction boxes.
    var circuitBox1 = circuits.First(c => c.Contains(shortestConnection.From));
    var circuitBox2 = circuits.First(c => c.Contains(shortestConnection.To));

    // If both junction boxes are not in the same circuit, merge the circuits and order by how big the new circuits are.
    if (circuitBox1 != circuitBox2)
    {
        circuitBox1.UnionWith(circuitBox2);
        circuits.Remove(circuitBox2);
        circuits = [.. circuits.OrderByDescending(c => c.Count)];
    }

    return circuits;
}

record JunctionBox(long X, long Y, long Z);

record Connection(JunctionBox From, JunctionBox To, long Distance);
