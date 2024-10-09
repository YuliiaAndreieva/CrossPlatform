using App;
using Xunit.Abstractions;

namespace Tests;

public class BinarySequenceServiceTests(ITestOutputHelper output)
{
    private readonly ITestOutputHelper _output = output;

    [Theory]
    [InlineData(1, 7)]    
    [InlineData(2, 11)]   
    [InlineData(3, 13)]   
    [InlineData(4, 14)]   
    [InlineData(5, 19)]   
    [InlineData(6, 21)]   
    [InlineData(7, 22)]   
    [InlineData(8, 25)]
    public void FindNthNumberWithThreeOnes_ReturnsCorrectValue(int n, int expected)
    {
        // Act
        _output.WriteLine($"Finding {n}-th number with three '1's in binary...");
        int result = BinarySequenceService.FindNthNumberWithThreeOnes(n);
        _output.WriteLine($"Expected: {expected}, Actual: {result}");

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0)]  
    [InlineData(-1)] 
    public void FindNthNumberWithThreeOnes_ThrowsException_WhenNIsLessThan1(int n)
    {
        // Act & Assert
        _output.WriteLine($"Checking for exception with input: {n}");
        Assert.Throws<Exceptions.InputException>(() => BinarySequenceService.FindNthNumberWithThreeOnes(n));
    }

    [Theory]
    [InlineData(0, 0)]    
    [InlineData(1, 1)]    
    [InlineData(2, 1)]    
    [InlineData(3, 2)]   
    [InlineData(7, 3)]    
    [InlineData(8, 1)]    
    [InlineData(13, 3)]   
    [InlineData(255, 8)]  
    [InlineData(1023, 10)] 
    public void CountOnesInBinary_ReturnsCorrectCount(int number, int expectedCount)
    {
        // Act
        _output.WriteLine($"Counting ones in binary representation of {number}...");
        int result = BinarySequenceService.CountOnesInBinary(number);
        _output.WriteLine($"Binary representation: {Convert.ToString(number, 2)}, Expected count: {expectedCount}, Actual count: {result}");

        // Assert
        Assert.Equal(expectedCount, result);
    }
    
    [Theory]
    [InlineData(2147483647, 31  )]   
    public void CountOnesInBinary_ReturnsCorrectCount_ForLargeNumber(int number, int expectedCount)
    {
        // Act
        _output.WriteLine($"Counting ones for large number {number}...");
        string binaryRepresentation = Convert.ToString(number, 2);
        _output.WriteLine($"Binary representation: {binaryRepresentation} (Length: {binaryRepresentation.Length})");

        int result = BinarySequenceService.CountOnesInBinary(number);
        _output.WriteLine($"Expected count of '1's: {expectedCount}, Actual count of '1's: {result}");

        // Assert
        Assert.Equal(expectedCount, result);
    }
    
    [Theory]
    [InlineData(123, 6)]   // Test for a medium number with six '1's in binary (1111011)
    [InlineData(1024, 1)]  // Test for a power of 2, binary representation is 10000000000 (1 '1')
    public void CountOnesInBinary_ReturnsCorrectCount_ForComplexNumbers(int number, int expectedCount)
    {
        // Act
        _output.WriteLine($"Counting ones for complex number {number}...");
        string binaryRepresentation = Convert.ToString(number, 2);
        _output.WriteLine($"Binary representation: {binaryRepresentation}");

        int result = BinarySequenceService.CountOnesInBinary(number);
        _output.WriteLine($"Expected count of '1's: {expectedCount}, Actual count of '1's: {result}");

        // Assert
        Assert.Equal(expectedCount, result);
    }
}