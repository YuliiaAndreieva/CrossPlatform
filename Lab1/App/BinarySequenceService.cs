namespace App;

public static class BinarySequenceService
{
    private const int StartNValue = 7;

    public static int CountOnesInBinary(int number)
    {
        return Convert.ToString(number, 2).Count(c => c == '1');
    }
    
    public static int FindNthNumberWithThreeOnes(int n)
    {
        if (n is 0 or < 0)
        {
            throw new Exceptions.InputException("Input contains invalid integer.");
        }
        
        int count = 0;
        int number = StartNValue;  

        while (true)
        {
            if (CountOnesInBinary(number) == 3) 
            {
                count++;
                if (count == n)
                {
                    return number;
                }
            }
            number++;
        }
    }
}