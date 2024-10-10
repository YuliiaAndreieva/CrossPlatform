
using System.Text;
using App;

Console.OutputEncoding = Encoding.Unicode;

int result = 0, n = 0;
List<(int ai, int bi)> suppliers = new List<(int ai, int bi)>();
try
{
    (n, suppliers)  = IOHandler.ReadInputData();
}
catch (Exception e)
{
    Console.WriteLine($"Error occured while reading file: {e.Message}");
}

try
{
    result = SocksPurchaseService.CalculateMinimumCost(n, suppliers);
    Console.WriteLine($"Minimum purchase value {result}");
}
catch(Exception e)
{
    Console.WriteLine($"Error occured while solving this task: {e.Message}");
}

try
{
    IOHandler.WriteResult(result);
}
catch (Exception e)
{
    Console.WriteLine($"Error occured while writing file: {e.Message}");
}