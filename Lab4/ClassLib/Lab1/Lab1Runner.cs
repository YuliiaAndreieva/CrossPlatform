using System.Numerics;

namespace ClassLib.Lab1;

public class Lab1Runner
{
    public static void Run(string inputPath, string outputPath)
    {
        int n;
        BigInteger nthValue;
        try
        {
            n = IOHandler.ReadNValue(inputPath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured while reading file: {e.Message}");
            return;
        }

        try
        {
            nthValue = BinarySequenceService.FindNthNumberWithThreeOnes(n);
            Console.WriteLine($"The {n}-th number in the sequence is: {nthValue}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error occured while solving this task: {e.Message}");
            return;
        }

        try
        {
            IOHandler.WriteResult(nthValue, outputPath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured while writing file: {e.Message}");
        }
    }
}