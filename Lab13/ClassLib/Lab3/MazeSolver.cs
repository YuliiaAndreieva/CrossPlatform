namespace ClassLib.Lab3;

public class MazeSolver
{
    private readonly int _r;
    private readonly int _c;
    private readonly int[] _costs;
    private readonly char[,] _grid;
    private readonly (int, int) _start;
    private readonly (int, int) _end;

    public MazeSolver(int rows, int columns, int[] keyCosts, char[] labyrinth1D)
    {
        _r = rows;
        _c = columns;
        _costs = keyCosts;
        _grid = new char[_r, _c];
        int startX = -1, startY = -1;
        int endX = -1, endY = -1;
        
        for (int r = 0; r < _r; r++)
        {
            for (int c = 0; c < _c; c++)
            {
                _grid[r, c] = labyrinth1D[r * _c + c];
                if (_grid[r, c] == 'S')
                {
                    startX = r;
                    startY = c;
                }
                if (_grid[r, c] == 'E')
                {
                    endX = r;
                    endY = c;
                }
            }
        }

        if (startX == -1 || startY == -1)
            throw new InvalidDataException("Position 'S' is not found.");
        if (endX == -1 || endY == -1)
            throw new InvalidDataException("Position 'E' is not found.");

        _start = (startX, startY);
        _end = (endX, endY);
    }

    public int FindMinimumCost()
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        bool[,,] visited = InitializeVisited();

        Queue<Node> queue = InitializeQueue(visited);

        int minCost = int.MaxValue;

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            if (IsAtEnd(current))
            {
                minCost = Math.Min(minCost, current.Cost);
                continue;
            }

            for (int dir = 0; dir < 4; dir++)
            {
                ProcessDirection(current, dir, dx, dy, queue, visited);
            }
        }

        return (minCost != int.MaxValue) ? minCost : -1;
    }

    private bool[,,] InitializeVisited()
    {
        return new bool[_r, _c, 16];
    }
    
    private Queue<Node> InitializeQueue(bool[,,] visited)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(new Node(_start.Item1, _start.Item2, 0, 0));
        visited[_start.Item1, _start.Item2, 0] = true;
        return queue;
    }
    
    private bool IsAtEnd(Node node)
    {
        return node.X == _end.Item1 && node.Y == _end.Item2;
    }
    
    private void ProcessDirection(Node current, int dir, int[] dx, int[] dy, Queue<Node> queue, bool[,,] visited)
    {
        int nx = current.X + dx[dir];
        int ny = current.Y + dy[dir];
        int nKeys = current.Keys;
        int nCost = current.Cost;

        if (!MazeHelper.IsWithinBounds(nx, ny, _r, _c))
            return;

        char cell = _grid[nx, ny];

        if (cell == 'X')
            return;

        if (MazeHelper.IsKey(cell))
        {
            int keyIndex = MazeHelper.GetKeyIndex(cell);
            if (keyIndex == -1)
                return; 
            
            if (!MazeHelper.HasKey(nKeys, keyIndex))
            {
                nKeys = MazeHelper.AddKey(nKeys, keyIndex);
                nCost += _costs[keyIndex];
            }
        }

        if (IsVisited(visited, nx, ny, nKeys))
            return;

        MarkVisited(visited, nx, ny, nKeys);
        queue.Enqueue(new Node(nx, ny, nKeys, nCost));
    }
    
    private bool IsVisited(bool[,,] visited, int x, int y, int keys)
    {
        return visited[x, y, keys];
    }
    
    private void MarkVisited(bool[,,] visited, int x, int y, int keys)
    {
        visited[x, y, keys] = true;
    }
}
