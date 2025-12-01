using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AocHelpers;


public class InputFileReader
{
    public static string ReadInputFile(string relativePath)
    {
        // Get the absolute path of the current working directory
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine the base directory and the relative path into a full path
        string fullPath = Path.Combine(currentDirectory, relativePath);

        // Ensure the file is copied to the output directory in Visual Studio
        // by setting the file's 'Copy to Output Directory' property to 'Copy if newer'.

        try
        {
            // Read the file using the constructed full path.
            return File.ReadAllText(fullPath);
        }
        catch
        {
            Console.WriteLine($"Error while reading file at: {fullPath}");
            throw;
        }
    }

    public static List<T> ReadInputFileToObjects<T>(string relativePath, string separator)
    {
        var inputString = ReadInputFile(relativePath);

        try
        {
            var stringArray = inputString.Split(separator).ToArray();
            var objArray = Array.ConvertAll(stringArray, item => (T)(object)item);
            return [.. objArray];
        }
        catch
        {
            Console.WriteLine($"Error while converting to object");
            throw;
        }
    }

    public static T? ReadJsonFileToObject<T>(string relativePath)
    {
        var jsonString = ReadInputFile(relativePath);

        try
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        catch
        {
            Console.WriteLine($"Error while converting to object");
            throw;
        }
    }
}