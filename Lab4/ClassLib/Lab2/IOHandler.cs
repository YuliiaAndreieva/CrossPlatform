﻿using System.Globalization;

namespace ClassLib.Lab2;

public static class IOHandler
{
    public static (int n, List<(int ai, int bi)> suppliers) ReadInputData(string inputPath)
    {
        if (!File.Exists(inputPath))
        {
            throw new IOException("Input file not found");
        }

        var lines = File.ReadAllLines(inputPath)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrEmpty(line))
            .ToList();

        if (lines.Count < 2)
        {
            throw new Exceptions.InputException("Input file does not contain enough data.");
        }

        var firstLine = lines[0].Split();
        if (firstLine.Length != 2 || 
            !int.TryParse(firstLine[0], out var n) || 
            !int.TryParse(firstLine[1], out var m) || n <= 0 || m <= 0)
        {
            throw new Exceptions.InputException("Invalid n or m value in input file.");
        }

        var suppliers = new List<(int ai, int bi)>();

        for (int i = 1; i <= m; i++)
        {
            var supplierData = lines[i].Split();
            if (supplierData.Length != 2 || 
                !int.TryParse(supplierData[0], out var ai) || 
                !int.TryParse(supplierData[1], out var bi) || ai <= 0 || bi <= 0)
            {
                throw new Exceptions.InputException("Invalid supplier data in input file.");
            }
            suppliers.Add((ai, bi));
        }

        return (n, suppliers);
    }
    
    public static void WriteResult(int result, string outputPath)
    {
        File.WriteAllText(outputPath, result.ToString(CultureInfo.InvariantCulture));
    }
}