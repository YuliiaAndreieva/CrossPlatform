namespace ClassLib.Lab2;

public class Lab2Runner
{
    public static int Run(int n, List<(int ai, int bi)> suppliers)
    {
        int result = 0;
        try
        {
            result = SocksPurchaseService.CalculateMinimumCost(n, suppliers);
            Console.WriteLine($"Minimum purchase value {result}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error occured while solving this task: {e.Message}");
        }

        return result;
    }
}