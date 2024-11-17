using System.Text;
using App;

Console.OutputEncoding = Encoding.Unicode;

int n, nthValue;
try
{
    n = IOHandler.ReadNValue();
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
    IOHandler.WriteResult(nthValue);
}
catch (Exception e)
{
    Console.WriteLine($"Error occured while writing file: {e.Message}");
}