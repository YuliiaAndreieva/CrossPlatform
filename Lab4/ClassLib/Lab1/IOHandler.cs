using System.Globalization;
using System.Numerics;

namespace ClassLib.Lab1;

public static class IOHandler
{
    public static int ReadNValue(string inputPath)
    {
        if (!File.Exists(inputPath))
        {
            throw new IOException("Input file not found");
        }

        var lines = File.ReadAllLines(inputPath)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrEmpty(line))
            .ToList();

        if (lines.Count == 0)
        {
            throw new Exceptions.InputException("Input file is empty.");
        }

        if (lines.Count != 1)
        {
            throw new Exceptions.InputException("Input file contains more than one line.");
        }

        if (!int.TryParse(lines[0], out var n))
        {
            throw new Exceptions.InputException("Input file contains invalid integer.");
        }
        
        if (n is 0 or < 0)
        {
            throw new Exceptions.InputException("Input file contains invalid integer.");
        }

        return n;
    }
    
    public static void WriteResult(BigInteger result, string outputPath)
    {
        File.WriteAllText(outputPath, result.ToString(CultureInfo.InvariantCulture));
    }
}