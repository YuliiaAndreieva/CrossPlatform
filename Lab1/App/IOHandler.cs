using System.Globalization;
using System.Numerics;

namespace App;

public static class IOHandler
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static int ReadNValue()
    {
        if (!File.Exists(InputFileName))
        {
            throw new IOException("Input file not found");
        }

        var lines = File.ReadAllLines(InputFileName)
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
    
    public static void WriteResult(BigInteger result)
    {
        File.WriteAllText(OutputFileName, result.ToString(CultureInfo.InvariantCulture));
    }
}