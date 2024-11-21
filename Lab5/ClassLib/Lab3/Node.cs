namespace ClassLib.Lab3;

public class Node(int x, int y, int keys, int cost)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public int Keys { get; } = keys;
    public int Cost { get; } = cost;
}