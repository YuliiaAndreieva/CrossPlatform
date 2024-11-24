namespace App.Validators;

public static class ThirdLabValidator
{
    public static void ValidateLabyrinth(List<List<char>> labyrinth)
    {
        int startCount = 0;
        int endCount = 0;

        foreach (var row in labyrinth)
        {
            foreach (var cell in row)
            {
                if (cell == 'S') startCount++;
                if (cell == 'E') endCount++;
            }
        }

        if (startCount != 1)
        {
            throw new ArgumentException("Лабіринт повинен містити рівно один символ 'S' (початкова позиція).");
        }

        if (endCount != 1)
        {
            throw new ArgumentException("Лабіринт повинен містити рівно один символ 'E' (вихід).");
        }
    }
}