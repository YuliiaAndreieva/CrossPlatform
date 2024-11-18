using App;
using Xunit.Abstractions;

namespace Tests;

public class TaskSolverTests()
{
    [Fact]
    public void Test_ExitReachableWithoutKeys()
    {
        // Arrange
        int rows = 3, cols = 3;
        int[] keyPrices = { 1, 1, 1, 1 };
        char[] labyrinth = {
            'S', '.', 'E',
            '.', 'X', '.',
            'X', '.', 'X'
        };
        var solver = new MazeSolver(rows, cols, keyPrices, labyrinth);

        // Act
        int result = solver.FindMinimumCost();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Test_ExitWithOneKeyRequired()
    {
        // Arrange
        int rows = 4, cols = 4;
        int[] keyPrices = { 2, 3, 1, 4 };
        char[] labyrinth = {
            'S', 'R', '.', '.',
            'X', 'X', '.', 'B',
            'X', 'X', '.', '.',
            'X', '.', '.', 'E'
        };
        var solver = new MazeSolver(rows, cols, keyPrices, labyrinth);

        // Act
        int result = solver.FindMinimumCost();

        // Assert
        Assert.Equal(2, result); 
    }

    [Fact]
    public void Test_ExitWithMultipleKeys()
    {
        // Arrange
        int rows = 5, cols = 5;
        int[] keyPrices = { 1, 2, 3, 4 };
        char[] labyrinth = {
            'S', '.', 'X', 'G', 'E',
            'X', '.', '.', '.', 'B',
            'X', 'X', '.', 'X', 'X',
            'X', 'X', 'Y', '.', 'R',
            'X', 'X', 'X', '.', '.'
        };
        var solver = new MazeSolver(rows, cols, keyPrices, labyrinth);

        // Act
        int result = solver.FindMinimumCost();

        // Assert
        Assert.Equal(2, result); 
    }

    [Fact]
    public void Test_NoExitAvailable()
    {
        // Arrange
        int rows = 3, cols = 3;
        int[] keyPrices = { 5, 5, 5, 5 };
        char[] labyrinth = {
            'S', 'X', 'X',
            'X', 'X', 'X',
            'X', 'X', 'E'
        };
        var solver = new MazeSolver(rows, cols, keyPrices, labyrinth);

        // Act
        int result = solver.FindMinimumCost();

        // Assert
        Assert.Equal(-1, result); 
    }
    
    
    [Theory]
    [InlineData(2, 3, 5, 5, true)]
    [InlineData(-1, 0, 5, 5, false)]
    [InlineData(0, -1, 5, 5, false)]
    [InlineData(5, 5, 5, 5, false)]
    public void IsWithinBounds_TestCoordinates_ReturnsExpected(int x, int y, int rows, int cols, bool expected)
    {
        // Act
        bool result = MazeHelper.IsWithinBounds(x, y, rows, cols);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData('R', true)]
    [InlineData('G', true)]
    [InlineData('B', true)]
    [InlineData('Y', true)]
    [InlineData('A', false)]
    [InlineData('Z', false)]
    [InlineData('1', false)]
    [InlineData('.', false)]
    public void IsKey_TestVariousCharacters_ReturnsExpected(char input, bool expected)
    {
        // Act
        bool result = MazeHelper.IsKey(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData('R', 0)]
    [InlineData('G', 1)]
    [InlineData('B', 2)]
    [InlineData('Y', 3)]
    [InlineData('A', -1)]
    [InlineData('Z', -1)]
    public void GetKeyIndex_TestVariousCharacters_ReturnsExpectedIndex(char input, int expected)
    {
        // Act
        int result = MazeHelper.GetKeyIndex(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0b1010, 1, true)]
    [InlineData(0b1010, 2, false)]
    [InlineData(0b1111, 3, true)]
    [InlineData(0b0000, 0, false)]
    public void HasKey_TestKeyPresence_ReturnsExpected(int keys, int keyIndex, bool expected)
    {
        // Act
        bool result = MazeHelper.HasKey(keys, keyIndex);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0b0000, 2, 0b0100)]
    [InlineData(0b0100, 2, 0b0100)]
    [InlineData(0b0010, 0, 0b0011)]
    [InlineData(0b1111, 3, 0b1111)]
    public void AddKey_TestAddingKeys_ReturnsExpectedKeys(int keys, int keyIndex, int expected)
    {
        // Act
        int result = MazeHelper.AddKey(keys, keyIndex);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void AddKey_AllKeysAlreadyPresent_NoChange()
    {
        // Arrange
        int keys = 0b1111;
        int keyIndex = 1; 

        // Act
        int result = MazeHelper.AddKey(keys, keyIndex);

        // Assert
        Assert.Equal(0b1111, result);
    }

    [Fact]
    public void HasKey_InvalidKeyIndex_ReturnsFalse()
    {
        // Arrange
        int keys = 0b1010;
        int keyIndex = 4; 

        // Act
        bool result = MazeHelper.HasKey(keys, keyIndex);

        // Assert
        Assert.False(result, "Expected HasKey to return false for invalid keyIndex.");
    }

    [Theory]
    [InlineData(0b0001, 0, 0b0001)]
    [InlineData(0b0010, 1, 0b0010)]
    [InlineData(0b0100, 2, 0b0100)]
    [InlineData(0b1000, 3, 0b1000)]
    public void AddKey_SingleKey_AddsCorrectly(int keys, int keyIndex, int expected)
    {
        // Act
        int result = MazeHelper.AddKey(keys, keyIndex);

        // Assert
        Assert.Equal(expected, result);
    }
}