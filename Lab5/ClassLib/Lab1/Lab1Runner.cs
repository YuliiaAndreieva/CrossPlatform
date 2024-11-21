using System.Numerics;

namespace ClassLib.Lab1;

public class Lab1Runner
{
    public static BigInteger Run(int n)
    {
        BigInteger nthValue = 0;
        try
        {
            nthValue = BinarySequenceService.FindNthNumberWithThreeOnes(n);
            Console.WriteLine($"The {n}-th number in the sequence is: {nthValue}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error occured while solving this task: {e.Message}");
        }

        return nthValue;
    }
}