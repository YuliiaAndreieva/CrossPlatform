using System.Text;
using App;

Console.OutputEncoding = Encoding.Unicode;

int result = -1; 
try
{
    var inputData = IOHandler.ReadInputData();
    int rows = inputData.rows;
    int cols = inputData.cols;
    int[] keyPrices = inputData.keyPrices;
    char[] labyrinth1D = inputData.labyrinth;
    
    MazeSolver solver = new MazeSolver(rows, cols, keyPrices, labyrinth1D);
    
    result = solver.FindMinimumCost();
    
    Console.WriteLine(result);
}
catch (Exception e)
{
    Console.WriteLine($"Error occurred while processing: {e.Message}");
    return;
}

try
{
    IOHandler.WriteResult(result);
}
catch (Exception e)
{
    Console.WriteLine($"Error occurred while writing result: {e.Message}");
}
