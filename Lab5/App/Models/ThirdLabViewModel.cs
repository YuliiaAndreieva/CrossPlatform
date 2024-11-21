namespace App.Models;

public class ThirdLabViewModel
{
    public int Rows { get; set; }
    public int Cols { get; set; }
    public Dictionary<char, int> KeyPrices { get; set; } = new();
    public List<List<char>> Labyrinth { get; set; } = new();
    public int? Result { get; set; }
    public string? ErrorMessage { get; set; }
}