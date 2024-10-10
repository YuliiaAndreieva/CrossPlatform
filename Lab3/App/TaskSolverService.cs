
namespace App;

public class TaskSolverService
{
    private readonly int _rows;
    private readonly int _cols;
    private readonly int[] _keyPrices;
    private readonly char[] _labyrinth;

    private TaskSolverService(
        int rows,
        int cols,
        int[] keyPrices,
        char[] labyrinth)
    {
        _rows = rows;
        _cols = cols;
        _keyPrices = keyPrices;
        _labyrinth = labyrinth;
    }

    public static TaskSolverService Create(
        int rows,
        int cols,
        int[] keyPrices,
        char[] labyrinth)
    {
        return new TaskSolverService(rows, cols, keyPrices, labyrinth);
    }

    private bool IsWithinBounds(
        int row,
        int col)
    {
        return row >= 0 && row < _rows && col >= 0 && col < _cols;
    }

    public int FindMinimumCostToExit(
        (int row, int col) startPosition)
    {
        var directions = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
        Queue<(int row, int col, int cost, int keys)> queue = new();
        Dictionary<(int, int, int), int> visited = new();

        queue.Enqueue((startPosition.row, startPosition.col, 0, 0));
        visited[(startPosition.row, startPosition.col, 0)] = 0;

        while (queue.Count > 0)
        {
            var (currentRow, currentCol, currentCost, currentKeys) = queue.Dequeue();
            
            if (_labyrinth[currentRow * _cols + currentCol] == 'E')
                return currentCost;

            foreach (var (dr, dc) in directions)
            {
                int newRow = currentRow + dr;
                int newCol = currentCol + dc;

                if (IsWithinBounds(newRow, newCol) && _labyrinth[newRow * _cols + newCol] != 'X')
                {
                    ProcessCell(queue, visited, newRow, newCol, currentCost, currentKeys);
                }
            }
        }
        return -1;
    }

    private void ProcessCell(
        Queue<(int, int, int, int)> queue,
        Dictionary<(int, int, int), int> visited,
        int newRow,
        int newCol,
        int currentCost,
        int currentKeys)
    {
        char cell = _labyrinth[newRow * _cols + newCol];

        if (cell == 'E')
        {
            queue.Enqueue((newRow, newCol, currentCost, currentKeys));
            return;
        }

        if ("RGBY".Contains(cell))
        {
            HandleDoorCell(queue, visited, newRow, newCol, currentCost, currentKeys, cell);
        }
        else
        {
            HandleEmptyCell(queue, visited, newRow, newCol, currentCost, currentKeys);
        }
    }

    private void HandleDoorCell(
        Queue<(int, int, int, int)> queue,
        Dictionary<(int, int, int), int> visited,
        int newRow,
        int newCol,
        int currentCost,
        int currentKeys,
        char cell)
    {
        int keyIndex = "RGBY".IndexOf(cell);
        int keyBit = 1 << keyIndex;

        int newCostWithKey = currentCost + _keyPrices[keyIndex];
        int newKeysWithKey = currentKeys | keyBit;

        if ((currentKeys & keyBit) == 0) 
        {
            if (!visited.ContainsKey((newRow, newCol, newKeysWithKey)) ||
                visited[(newRow, newCol, newKeysWithKey)] > newCostWithKey)
            {
                visited[(newRow, newCol, newKeysWithKey)] = newCostWithKey;
                queue.Enqueue((newRow, newCol, newCostWithKey, newKeysWithKey));
            }
        }
        else
        {
            HandleEmptyCell(queue, visited, newRow, newCol, currentCost, currentKeys);
        }
    }

    private static void HandleEmptyCell(
        Queue<(int, int, int, int)> queue,
        Dictionary<(int, int, int), int> visited,
        int newRow,
        int newCol,
        int currentCost,
        int currentKeys)
    {
        if (!visited.ContainsKey((newRow, newCol, currentKeys)) ||
            visited[(newRow, newCol, currentKeys)] > currentCost)
        {
            visited[(newRow, newCol, currentKeys)] = currentCost;
            queue.Enqueue((newRow, newCol, currentCost, currentKeys));
        }
    }
}
