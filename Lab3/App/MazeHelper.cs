namespace App;

public static class MazeHelper
{
    public static bool IsWithinBounds(int x, int y, int rows, int cols)
    {
        return x >= 0 && x < rows && y >= 0 && y < cols;
    }
    
    public static bool IsKey(char c)
    {
        return c == 'R' || c == 'G' || c == 'B' || c == 'Y';
    }
    
    public static int GetKeyIndex(char c)
    {
        return c switch
        {
            'R' => 0,
            'G' => 1,
            'B' => 2,
            'Y' => 3,
            _ => -1
        };
    }
    
    public static bool HasKey(int keys, int keyIndex)
    {
        return ((keys >> keyIndex) & 1) == 1;
    }
    
    public static int AddKey(int keys, int keyIndex)
    {
        return keys | (1 << keyIndex);
    }
}