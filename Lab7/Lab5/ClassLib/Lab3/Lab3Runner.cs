using System.Text;

namespace ClassLib.Lab3;

public class Lab3Runner
{
    public static int Run(int rows, int cols, int[] keyCosts, char[] labyrinth1D)
    {
        int result = -1; 
        try
        {
            MazeSolver solver = new MazeSolver(rows, cols, keyCosts, labyrinth1D);
            result = solver.FindMinimumCost();
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error occured while solving this task: {e.Message}");
        }

        return result;
    }
}