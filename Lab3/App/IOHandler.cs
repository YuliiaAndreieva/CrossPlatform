namespace App;

public static class IOHandler
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";
    
    public static (int rows, int cols, int[] keyPrices, char[] labyrinth) ReadInputData()
    {
        using var reader = new StreamReader(InputFileName);
        var dimensions = reader.ReadLine()?.Split();
        int rows = int.Parse(dimensions?[0] ?? string.Empty);
        int cols = int.Parse(dimensions?[1] ?? string.Empty);
            
        var keyPrices = Array.ConvertAll(reader.ReadLine()?.Split() ?? Array.Empty<string>(), int.Parse);
            
        char[,] labyrinth2D = new char[rows, cols];
        for (int r = 0; r < rows; r++)
        {
            string? line = reader.ReadLine();
            for (int c = 0; c < cols; c++)
            {
                if (line != null) labyrinth2D[r, c] = line[c];
            }
        }
            
        char[] labyrinth = new char[rows * cols];
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                labyrinth[r * cols + c] = labyrinth2D[r, c];
            }
        }

        return (rows, cols, keyPrices, labyrinth);
    }

    public static void WriteResult(int result)
    {
        using var writer = new StreamWriter(OutputFileName);
        writer.WriteLine(result >= 0 ? result.ToString() : "Sleep");
    }
    
}