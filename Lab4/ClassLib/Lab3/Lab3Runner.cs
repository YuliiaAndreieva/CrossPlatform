using System.Text;

namespace ClassLib.Lab3;

public class Lab3Runner
{
    public static void Run(string inputPath, string outputPath)
    {
        Console.OutputEncoding = Encoding.Unicode;

        int result = -1; 
        try
        {
            var inputData = IOHandler.ReadInputData(inputPath);
            MazeSolver solver = new MazeSolver(inputData.rows, inputData.cols, inputData.keyPrices, inputData.labyrinth);
            result = solver.FindMinimumCost();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred while processing: {e.Message}");
            return;
        }

        try
        {
            IOHandler.WriteResult(result, outputPath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred while writing result: {e.Message}");
        }
    }
}