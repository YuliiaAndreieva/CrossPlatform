using System.Text;
using App;

Console.OutputEncoding = Encoding.Unicode;

int result = -1; 
try
{
    var (rows, cols, keyPrices, labyrinth) = IOHandler.ReadInputData();
    
    var solver = TaskSolverService.Create(rows, cols, keyPrices, labyrinth);
    
    (int startRow, int startCol) = FindStartPosition(labyrinth, rows, cols);
    
    result = solver.FindMinimumCostToExit((startRow, startCol));
}
catch (Exception e)
{
    Console.WriteLine($"Error occurred while processing: {e.Message}");
}

try
{
    IOHandler.WriteResult(result);
}
catch (Exception e)
{
    Console.WriteLine($"Error occurred while writing result: {e.Message}");
}


static (int row, int col) FindStartPosition(char[] labyrinth, int rows, int cols)
{
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            if (labyrinth[r * cols + c] == 'S')
            {
                return (r, c); 
            }
        }
    }

    return (0, 0);
}
