namespace Day11;

public class Device(string name)
{
    public string Name { get; set; } = name;
    public List<Device> Outputs { get; set; } = [];

    public List<string> OutputNames { get; set; } = [];

    public static Device Parse(string input, int _)
    {
        var parts = input.Split(" ");
        var deviceName = parts[0][..^1].Trim();
        var device = new Device(deviceName);

        if (parts.Length > 1)
        {
            for (int i = 1; i < parts.Length; i++)
            {
                device.OutputNames.Add(parts[i].Trim());
            }
        }

        return device;
    }

    public void LookUpDevices(List<Device> devices)
    {
        foreach (var outputName in OutputNames)
        {
            var device = devices.Find(d => d.Name.Equals(outputName, StringComparison.OrdinalIgnoreCase)) ?? throw new Exception($"Device with name {outputName} not found.");
            Outputs.Add(device);
        }
    }

    public long CountAmountOfPathsTo(string deviceNameToFind)
    {
        if (Name.Equals(deviceNameToFind, StringComparison.OrdinalIgnoreCase))
        {
            return 1;
        }

        long totalPaths = 0;
        foreach (var output in Outputs)
        {
            totalPaths += output.CountAmountOfPathsTo(deviceNameToFind);
        }

        return totalPaths;
    }
}
