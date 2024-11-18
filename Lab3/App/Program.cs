using System.Text;
using App;

Console.OutputEncoding = Encoding.Unicode;

int result = -1; 
try
{
    var inputData = IOHandler.ReadInputData();
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
    IOHandler.WriteResult(result);
}
catch (Exception e)
{
    Console.WriteLine($"Error occurred while writing result: {e.Message}");
}
