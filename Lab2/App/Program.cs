using System.Text;
using App;

Console.OutputEncoding = Encoding.Unicode;

int result, n;
List<(int ai, int bi)> suppliers;
try
{
    (n, suppliers)  = IOHandler.ReadInputData();
}
catch (Exception e)
{
    Console.WriteLine($"Error occured while reading file: {e.Message}");
    return;
}

try
{
    result = SocksPurchaseService.CalculateMinimumCost(n, suppliers);
    Console.WriteLine($"Minimum purchase value {result}");
}
catch(Exception e)
{
    Console.WriteLine($"Error occured while solving this task: {e.Message}");
    return;
}

try
{
    IOHandler.WriteResult(result);
}
catch (Exception e)
{
    Console.WriteLine($"Error occured while writing file: {e.Message}");
}